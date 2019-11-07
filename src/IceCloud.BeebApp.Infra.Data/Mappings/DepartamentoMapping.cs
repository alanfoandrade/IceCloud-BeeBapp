using System.Data.Entity.ModelConfiguration;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Mappings
{
    public class DepartamentoMapping : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoMapping()
        {
            HasKey(d => d.Id);

            Property(d => d.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            // Departamento:Empresa (N:1)
            HasRequired(d => d.Empresa)
                .WithMany(e => e.Departamentos)
                .HasForeignKey(d => d.EmpresaId);

            ToTable("Departamentos", "Operacional");
        }
    }
}