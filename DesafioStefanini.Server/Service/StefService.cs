using DesafioStefanini.Server.Context;
using DesafioStefanini.Server.Interface;
using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DesafioStefanini.Server.Service
{
   
    public class StefService : IStefService
    {
        private readonly StefDbContext context;

        public StefService(StefDbContext context) 
        {
            this.context = context;
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            return context.Pedidos;
        }

        public Pedido CriarPedido(Pedido pedido)
        {

            context.Pedidos.Add(pedido);
            context.SaveChangesAsync();

            return pedido;

        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            var atualizado = context.Update(pedido);
            context.SaveChanges();

            return pedido;
        }

        public ActionResult<Pedido?> GetPedidoPorId(int id)
        {
            var pedido = context.Pedidos.Find(id);

            return pedido;

        }

        public ActionResult<int> DeletePedido(int id)
        {
            var pedido = context.Pedidos.Find(id);

            context.Pedidos.Remove(pedido);

            return pedido.Id;
        }
    }
}
