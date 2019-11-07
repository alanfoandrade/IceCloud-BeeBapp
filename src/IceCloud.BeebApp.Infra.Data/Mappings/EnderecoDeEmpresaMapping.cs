using System.Data.Entity.ModelConfiguration;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Mappings
{
    public class EnderecoDeEmpresaMapping : EntityTypeConfiguration<EnderecoEmpresa>
    {
        public EnderecoDeEmpresaMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .HasMaxLength(100);

            // Endereco:Usuario (N:1) (or zero "HasOptional")
            HasRequired(e => e.Empresa)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(e => e.EmpresaId);

            ToTable("EnderecosEmpresas", "Operacional");
        }
    }
}