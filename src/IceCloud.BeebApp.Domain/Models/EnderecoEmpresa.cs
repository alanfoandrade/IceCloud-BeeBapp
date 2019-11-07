using System;

namespace IceCloud.BeebApp.Domain.Models
{
    public class EnderecoEmpresa : Endereco
    {
        // Relacionamentos
        // Endereco:Empresa (N:1)
        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}