using System;
using System.Collections.Generic;

namespace IceCloud.BeebApp.Domain.Models
{
    public class TipoUsuario : Entity
    {
        public string Tipo { get; set; }


        // Relacionamentos
        // TipoUsuario:Usuario (N:1)
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public override bool IsValid()
        {
            {
                if (string.IsNullOrWhiteSpace(Tipo))
                    AddValidationError("Tipo de Usuário", "Tipo de Usuário não pode estar em branco");

                return ValidationResult.Count == 0;
            }
        }
    }
}