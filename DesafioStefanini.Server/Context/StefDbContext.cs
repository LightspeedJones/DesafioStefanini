using DesafioStefanini.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Server.Context
{
    public class StefDbContext : DbContext
    {
        public StefDbContext(DbContextOptions<StefDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Pedido>().HasMany(x => x.ItensPedido).WithOne(x => x.Pedido).IsRequired(false);
            //modelBuilder.Entity<ItensPedido>().HasOne(x => x.Pedido).WithMany(x => x.ItensPedido).HasForeignKey(x => x.IdPedido).HasForeignKey(x => x.IdProduto);
            //modelBuilder.Entity<Produto>().HasMany(x => x.ItensPedidos).WithOne(x => x.Produto);

            modelBuilder.Entity<Pedido>().HasMany(x => x.ItensPedido).WithOne(x => x.Pedido).HasForeignKey(x => x.IdPedido).HasPrincipalKey(x => x.Id);

        }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            var appDb = serviceProvider.GetRequiredService<StefDbContext>();

            if (!appDb.Produtos.Any())
            {
                appDb.Produtos.Add(new Produto { Id = 1, NomeProduto = "Batata frita", Valor = 3 });
                appDb.Produtos.Add(new Produto { Id = 2, NomeProduto = "Coca-Cola", Valor = 4 });
                appDb.Produtos.Add(new Produto { Id = 3, NomeProduto = "Cheeseburger", Valor = 4 });
                appDb.Produtos.Add(new Produto { Id = 4, NomeProduto = "Bolo de chocolate", Valor = 3 });

                appDb.SaveChanges();
            }
        }

        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
