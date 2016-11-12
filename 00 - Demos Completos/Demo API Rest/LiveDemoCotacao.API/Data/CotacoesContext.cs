using LiveDemoCotacao.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveDemoCotacao.API.Data
{
    public class CotacoesContext : DbContext
    {
        public DbSet<Cotacao> Cotacoes { get; set; }

        public CotacoesContext(DbContextOptions<CotacoesContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>().HasKey(pk=>pk.Sigla);
        }
    }
}
