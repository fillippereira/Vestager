using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Vestager.Domain.Entities;

namespace Vestager.Infra.Data
{
    public class Context : IdentityDbContext<Usuario>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public Context() { }

      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Vestido>().ToTable("Vestidos");
            builder.Entity<VestidoCurto>();
            builder.Entity<VestidoLongo>();
        }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Ajuste> Ajustes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Locacao> Locacoes { get; set; }
        public virtual DbSet<Prova> Provas { get; set; }
        public virtual DbSet<Vestido> Vestidos { get; set; }
       

    }
}
