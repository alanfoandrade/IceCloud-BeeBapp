using System;

namespace IceCloud.BeebApp.Domain.Models
{
    public class Departamento : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }


        // Departamento:Empresa (N:1)
        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }


        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddValidationError("Nome", "Nome não pode estar em branco");

            if (string.IsNullOrWhiteSpace(Descricao))
                AddValidationError("Descricao", "Descricao não pode estar em branco");

            return ValidationResult.Count == 0;
        }
    }
}