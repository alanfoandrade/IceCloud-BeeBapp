using System.Data.Entity.ModelConfiguration;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Mappings
{
    public class TipoUsuarioMapping : EntityTypeConfiguration<TipoUsuario>
    {
        public TipoUsuarioMapping()
        {
            HasKey(t => t.Id);

            Property(t => t.Tipo)
                .IsRequired();

            Property(t => t.Ativo)
                .IsRequired();

            Property(t => t.Excluido)
                .IsRequired();

            // TipoUsuario:Usuario (N:1)
            HasRequired(t => t.Usuario)
                .WithMany(u => u.Tipos)
                .HasForeignKey(t => t.UsuarioId);

            ToTable("TipoUsuarios", "Operacional");
        }
    }
}