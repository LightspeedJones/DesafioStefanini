using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Server.Interface
{
    public interface IPedidoRepositorio
    {
        IEnumerable<dynamic> GetPedidoPorId(int id);
        int DeletePedido(int id);
        Pedido AtualizarPedido(Pedido pedido);
        IEnumerable<dynamic> GetPedidos();
        Pedido CriarPedido(Pedido pedido);
    }
}
