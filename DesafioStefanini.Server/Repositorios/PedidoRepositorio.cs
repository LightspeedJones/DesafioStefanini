using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Server.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly StefDbContext context;

        public PedidoRepositorio(StefDbContext context)
        {
            this.context = context;
        }

        public dynamic GetPedidoPorId(int id)
        {
            var pedido = (from p in context.Pedidos
                          join ip in context.ItensPedido on p.Id equals ip.IdPedido
                          join pr in context.Produtos on ip.IdProduto equals pr.Id
                          where p.Id == id
                          group new { p, ip, pr } by new { p.Id, p.NomeCliente, p.EmailCliente, p.Pago} into grp
                          select new
                          {
                              grp.Key.Id,
                              grp.Key.NomeCliente,
                              grp.Key.EmailCliente,
                              grp.Key.Pago,
                              ValorTotal = grp.Sum(x => x.pr.Valor * x.ip.Quantidade),
                              ItensPedido = context.ItensPedido.Where(x => x.IdPedido == id).Join(context.Produtos, ip => ip.IdProduto, pr => pr.Id, (ip, pr) => new
                              {
                                  ip.Id,
                                  ip.IdProduto,
                                  pr.NomeProduto,
                                  valorUnitario = pr.Valor,
                                  ip.Quantidade

                              }).AsEnumerable()
                          }).AsEnumerable().FirstOrDefault();


            return pedido;

        }

        public int DeletePedido(int id)
        {
            var pedido = context.Pedidos.Find(id);

            context.Pedidos.Remove(pedido);

            context.SaveChanges();

            return pedido.Id;
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            var itensPedido = context.ItensPedido.Where(x => x.IdPedido == pedido.Id);
            context.RemoveRange(itensPedido);
            var atualizado = context.Update(pedido);

            context.SaveChanges();

            return pedido;
        }

        public IEnumerable<dynamic> GetPedidos()
        {
            var pedido = (from p in context.Pedidos
                          join ip in context.ItensPedido on p.Id equals ip.IdPedido
                          join pr in context.Produtos on ip.IdProduto equals pr.Id
                          group new { p, ip, pr } by new { p.Id, p.NomeCliente, p.EmailCliente, p.Pago } into grp
                          select new
                          {
                              grp.Key.Id,
                              grp.Key.NomeCliente,
                              grp.Key.EmailCliente,
                              grp.Key.Pago,
                              ValorTotal = grp.Sum(x => x.pr.Valor * x.ip.Quantidade),
                              ItensPedido = context.ItensPedido.Where(x => x.IdPedido == grp.Key.Id).Join(context.Produtos, ip => ip.IdProduto, pr => pr.Id, (ip, pr) => new
                              {
                                  ip.Id,
                                  ip.IdProduto,
                                  pr.NomeProduto,
                                  valorUnitario = pr.Valor,
                                  ip.Quantidade

                              }).AsEnumerable()
                          }).AsEnumerable();

            return pedido;
        }

        public Pedido CriarPedido(Pedido pedido)
        {

            context.Pedidos.Add(pedido);
            context.SaveChangesAsync();

            return pedido;

        }

        public IEnumerable<Produto>? GetProdutos()
        {
            return context.Produtos.AsEnumerable();
        }
    }
}
