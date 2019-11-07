using System;
using System.Collections.Generic;

namespace IceCloud.BeebApp.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new Dictionary<string, string>();
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public void SetExcluido()
        {
            Ativo = false;
            Excluido = true;
        }

        public void SetAtivo()
        {
            Ativo = true;
            Excluido = false;
        }

        public void SetInativo()
        {
            Ativo = false;
            Excluido = false;
        }

        public IDictionary<string, string> ValidationResult { get; set; }

        public void AddValidationError(string erro, string msg)
        {
            ValidationResult.Add(erro, msg);
        }

        public abstract bool IsValid();
    }
}
