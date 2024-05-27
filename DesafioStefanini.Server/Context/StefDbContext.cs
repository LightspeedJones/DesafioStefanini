using DesafioStefanini.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Server.Context
{
    public class StefDbContext : DbContext
    {
        public StefDbContext(DbContextOptions<StefDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>().HasMany(x => x.ItensPedido).WithMany();          

            modelBuilder.Entity<Produto>().HasData(new Produto { Id = 1, NomeProduto = "Batata frita", Valor = 3 });
            modelBuilder.Entity<Produto>().HasData(new Produto { Id = 2, NomeProduto = "Coca-Cola", Valor = 4 });
            modelBuilder.Entity<Produto>().HasData(new Produto { Id = 3, NomeProduto = "Cheeseburger", Valor = 4 });
            modelBuilder.Entity<Produto>().HasData(new Produto { Id = 4, NomeProduto = "Bolo de chocolate", Valor = 3 });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("StefDb");
        //}

        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
