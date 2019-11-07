using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            HasKey(u => u.Id);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(u => u.DataNascimento)
                .IsRequired();

            Property(u => u.Ativo)
                .IsRequired();

            Property(u => u.Excluido)
                .IsRequired();

            // Usuario:Empresa (N:1)
            HasOptional(u => u.Empresa)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(u => u.EmpresaId);


            ToTable("Usuarios", "Operacional");
        }
    }
}
