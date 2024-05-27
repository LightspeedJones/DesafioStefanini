using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Server.Interface
{
    public interface IStefService
    {
        Pedido CriarPedido(Pedido pedido);
        IEnumerable<Pedido> GetPedidos();
        ActionResult<int> DeletePedido(int id);
        ActionResult<Pedido?> GetPedidoPorId(int id);
        Pedido AtualizarPedido(Pedido pedido);
    }
}
