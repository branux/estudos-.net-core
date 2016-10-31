using CadCli.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadCli.Data
{
    public class CadCliContext : DbContext
    {
        public CadCliContext()
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CadCliCore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(cli =>
            {
                cli.HasKey(c => c.Id);

                cli.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("int")
                    .ValueGeneratedOnAdd();

                cli.Property(col => col.Nascimento)
                    .HasColumnName("Nascimento")
                    .HasColumnType("datetime").IsRequired();

                cli.Property(col => col.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType($"varchar(50)")
                    .IsRequired();
            });

            modelBuilder.Entity<Produto>(prod =>
            {
                prod.HasKey(c => c.Id);

                prod.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("int")
                    .ValueGeneratedOnAdd();

                prod.Property(col => col.Fabricacao)
                    .HasColumnName("Fabricacao")
                    .HasColumnType("datetime").IsRequired();

                prod.Property(col => col.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType($"varchar(50)")
                    .IsRequired();

                prod.Property(col => col.Descricao)
                    .HasColumnName("Descricao")
                    .HasColumnType($"varchar(50)")
                    .IsRequired();

                prod.Property(col => col.Valor)
                    .HasColumnName("Valor")
                    .HasColumnType($"decimal(5,2)").IsRequired();
            });

            modelBuilder.Entity<Pedido>(ped =>
            {
                ped.HasKey(c => c.Id);

                ped.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                ped.Property(col => col.Data)
                    .HasColumnName("Data")
                    .HasColumnType("datetime").IsRequired();

                ped.Property(col => col.ClienteId)
                   .HasColumnName("ClienteId").HasColumnType("int");

            });

            modelBuilder.Entity<Pedido>()
                .HasOne(col => col.Cliente)
                .WithMany(col => col.Pedidos)
                .HasForeignKey(col => col.ClienteId);

            modelBuilder.Entity<ItemPedido>(item =>
            {
                item.HasKey(c => c.Id);

                item.Property(col => col.Id)
                    .HasColumnName("Id").HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                item.Property(col => col.ProdutoId)
                  .HasColumnName("ProdutoId").HasColumnType("int");

                item.Property(col => col.PedidoId)
                  .HasColumnName("PedidoId").HasColumnType("uniqueidentifier");

                item.Property(col => col.Valor)
                    .HasColumnName("Valor")
                    .HasColumnType($"decimal(5,2)").IsRequired();
            });

            modelBuilder.Entity<ItemPedido>()
                .HasOne(pt => pt.Pedido)
                .WithMany(t => t.Itens)
                .HasForeignKey(pt => pt.PedidoId);

            modelBuilder.Entity<ItemPedido>()
                .HasOne(pt => pt.Produto)
                .WithMany(t => t.ItensPedidos)
                .HasForeignKey(pt => pt.ProdutoId);
        }
    }
}
