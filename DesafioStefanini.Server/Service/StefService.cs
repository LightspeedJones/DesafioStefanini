using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace DesafioStefanini.Server.Service
{
   
    public class StefService : IStefService
    {
        private readonly IPedidoRepositorio pedidoRepositorio;

        public StefService(StefDbContext context, IPedidoRepositorio repositorio) 
        {
            this.pedidoRepositorio = repositorio;
        }

        public dynamic GetPedidoPorId(int id)
        {
            return this.pedidoRepositorio.GetPedidoPorId(id);
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

        public IEnumerable<Produto>? GetProdutos()
        {
            return this.pedidoRepositorio.GetProdutos();
        }
    }
}
