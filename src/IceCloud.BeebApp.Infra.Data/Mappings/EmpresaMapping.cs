using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Mappings
{
    public class EmpresaMapping : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.NomeFantasia)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.RazaoSocial)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.CNPJ)
                .IsRequired()
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CNPJ") { IsUnique = true }));

            Property(e => e.TEL)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            ToTable("Empresas", "Operacional");

        }
    }
}