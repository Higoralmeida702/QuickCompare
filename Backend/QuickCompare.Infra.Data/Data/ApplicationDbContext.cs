using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Infra.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CelularEntity> Celulares { get; set; }
        public DbSet<NotebookEntity> Notebooks { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CelularEntity>()
                .OwnsOne(x => x.Tela);

            modelBuilder.Entity<NotebookEntity>()
            .OwnsOne(x => x.Tela);
        }
    }
}