using DesafioStefanini.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Server.Interface
{
    public interface IStefService
    {
        dynamic GetPedidoPorId(int id);
        Pedido CriarPedido(Pedido pedido);
        Pedido AtualizarPedido(Pedido pedido);
        int DeletarPedido(int id);
        IEnumerable<dynamic> GetPedidos();
        IEnumerable<Produto>? GetProdutos();
    }
}
