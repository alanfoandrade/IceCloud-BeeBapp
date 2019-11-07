using System.Data.Entity.ModelConfiguration;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Mappings
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public ProdutoMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            // Produto:Empresa (N:1)
            HasRequired(p => p.Empresa)
                .WithMany(e => e.Produtos)
                .HasForeignKey(p => p.EmpresaId);

            ToTable("Produtos", "Operacional");
        }
    }
}