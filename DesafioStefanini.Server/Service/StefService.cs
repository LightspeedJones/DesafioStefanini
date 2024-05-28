using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Model;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace DesafioStefanini.Server.Service
{
   
    public class StefService : IStefService
    {
        //private readonly StefDbContext context;
        private readonly IPedidoRepositorio pedidoRepositorio;

        public StefService(StefDbContext context, IPedidoRepositorio repositorio) 
        {
            //this.context = context;
            this.pedidoRepositorio = repositorio;
        }

        public IEnumerable<dynamic> GetPedidoPorId(int id)
        {
            var response = this.pedidoRepositorio.GetPedidoPorId(id);

            return response;
        }

        public Pedido CriarPedido(Pedido pedido)
        {
            return this.pedidoRepositorio.CriarPedido(pedido);
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            return this.pedidoRepositorio.AtualizarPedido(pedido);
        }

        public int DeletarPedido(int id)
        {
           return this.pedidoRepositorio.DeletePedido(id);
        }

        public IEnumerable<dynamic> GetPedidos()
        {
            return this.pedidoRepositorio.GetPedidos();
        }

        //public IQueryable<Produto> GetProdutos()
        //{
        //    return this.pedidoRepositorio.GetProdutos();
        //}

        //public IEnumerable<Pedido> GetPedidos()
        //{
        //    return context.Pedidos;
        //}

        //public Pedido CriarPedido(Pedido pedido)
        //{

        //    context.Pedidos.Add(pedido);
        //    context.SaveChangesAsync();

        //    return pedido;

        //}

        //public Pedido AtualizarPedido(Pedido pedido)
        //{
        //    var atualizado = context.Update(pedido);
        //    context.SaveChanges();

        //    return pedido;
        //}

        //public IQueryable<dynamic> GetPedidoPorId(int id)
        //{
        //    //var pedido = context.Pedidos.Find(id);

        //    var pedido = (from p in context.Pedidos
        //                  join ip in context.ItensPedido on p.Id equals ip.IdPedido
        //                  join pr in context.Produtos on ip.IdProduto equals pr.Id
        //                  where p.Id == id
        //                  group new {p, ip, pr} by new {p.Id, p.NomeCliente, p.EmailCliente, p.Pago} into grp
        //                  select new
        //                  {
        //                      grp.Key.Id,
        //                      grp.Key.NomeCliente,
        //                      grp.Key.EmailCliente,
        //                      grp.Key.Pago,
        //                      ValorTotal = grp.Sum(x => x.pr.Valor * x.ip.Quantidade)
        //                  }).AsQueryable();

        //    return pedido;

        //}

        //public IQueryable<dynamic> GetItensPedido(int pedidoId)
        //{
        //    var pedidoItens = (from ip in context.ItensPedido
        //                  join pr in context.Produtos on ip.IdProduto equals pr.Id
        //                  where ip.IdPedido == pedidoId
        //                  select new
        //                  {
        //                      ip.Id,
        //                      IdProduto = pr.Id,
        //                      pr.NomeProduto,
        //                      pr.Valor,
        //                      ip.Quantidade
        //                  }).AsQueryable();

        //    return pedidoItens;
        //}

        //public ActionResult<int> DeletePedido(int id)
        //{
        //    var pedido = context.Pedidos.Find(id);

        //    context.Pedidos.Remove(pedido);

        //    return pedido.Id;
        //}
    }
}
