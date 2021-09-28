using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoVendas.Context
{
    public class ContextDB : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        public ContextDB(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Endereco>()
               .HasKey(p => p.Id);
            modelBuilder.Entity<Endereco>()
                .Property(p => p.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
