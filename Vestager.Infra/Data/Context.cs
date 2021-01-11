using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vestager.Domain;

namespace Vestager.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Locacao> Locacoes { get; set; }
        public virtual DbSet<Prova> Provas { get; set; }
        public virtual DbSet<Vestido> Vestidos { get; set; }

    }
}
