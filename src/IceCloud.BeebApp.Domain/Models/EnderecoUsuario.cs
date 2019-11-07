using System;

namespace IceCloud.BeebApp.Domain.Models
{
    public class EnderecoUsuario : Endereco
    {
        // Relacionamentos
        // Endereco:Usuario (N:1)
        public Guid UsuarioId { get; set; } // Id do Usuario a quem pertence o Endereço
        // Propriedade de Navegação do EF (faz o relacionamento Endereço->Usuario)
        public virtual Usuario Usuario { get; set; }
    }
}