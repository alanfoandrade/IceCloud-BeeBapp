using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using IceCloud.BeebApp.Domain.Models;
using IceCloud.BeebApp.Infra.Data.Mappings;

namespace IceCloud.BeebApp.Infra.Data.Context
{
    public class BeebAppContext : DbContext
    {
        public BeebAppContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EnderecoUsuario> EnderecosUsuarios { get; set; }
        public DbSet<EnderecoEmpresa> EnderecosEmpresas { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //modelBuilder.HasDefaultSchema("Operacional");

            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new EnderecoDeUsuarioMapping());
            modelBuilder.Configurations.Add(new EnderecoDeEmpresaMapping());
            modelBuilder.Configurations.Add(new TipoUsuarioMapping());
            modelBuilder.Configurations.Add(new EmpresaMapping());
            modelBuilder.Configurations.Add(new DepartamentoMapping());
            modelBuilder.Configurations.Add(new ProdutoMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
