using System;
using System.Collections.Generic;

namespace IceCloud.BeebApp.Domain.Models
{
    public class Usuario : Entity
    {
        public Usuario()
        {
            Enderecos = new List<EnderecoUsuario>();
            Tipos = new List<TipoUsuario>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Foto { get; set; }
        public DateTime DataNascimento { get; set; }


        // Relacionamentos
        // Usuario:Endereco (1:N)
        public virtual ICollection<EnderecoUsuario> Enderecos { get; set; }
        // Usuario:TipoUsuario (1:N)
        public virtual ICollection<TipoUsuario> Tipos { get; set; }

        // Usuario:Empresa (N:1)
        public Guid? EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }


        public void AddEndereco(EnderecoUsuario endereco)
        {
            if (!endereco.IsValid())
            {
                ValidationResult = endereco.ValidationResult;
                return;
            }

            Enderecos.Add(endereco);
        }

        public void AddTipo(TipoUsuario tipo)
        {
            if (!tipo.IsValid())
            {
                ValidationResult = tipo.ValidationResult;
                return;
            }

            Tipos.Add(tipo);
        }


        // Validações
        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddValidationError("Nome", "Nome não pode estar em branco");

            if (string.IsNullOrWhiteSpace(Email))
                AddValidationError("Email", "Email não pode estar em branco");

            return ValidationResult.Count == 0;
        }
    }
}
