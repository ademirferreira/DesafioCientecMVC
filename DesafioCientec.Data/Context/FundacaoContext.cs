using DesafioCientec.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioCientec.Data.Context
{
    public class FundacaoContext : DbContext
    {
        public FundacaoContext(DbContextOptions options) : base(options) { }

        public DbSet<Fundacao> Fundacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fundacao>().HasKey(f => f.Id);
            modelBuilder.Entity<Fundacao>()
                .Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(400)");

            modelBuilder.Entity<Fundacao>()
                .Property(f => f.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            modelBuilder.Entity<Fundacao>()
                .Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Fundacao>()
                .Property(p => p.Telefone)
                .IsRequired()
                .HasColumnType("varchar(15)");

            modelBuilder.Entity<Fundacao>()
                .Property(f => f.InstituicaoApoiada)
                .HasColumnType("varchar(400)");
        }
    }
}