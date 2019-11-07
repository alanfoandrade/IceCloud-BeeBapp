using System;

namespace IceCloud.BeebApp.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }


        // Relacionamentos
        // Produto:Empresa (N:1)
        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }


        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddValidationError("Nome", "Nome não pode estar em branco");

            return ValidationResult.Count == 0;
        }
    }
}