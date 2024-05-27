

using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Server.Model
{
    [PrimaryKey(nameof(IdPedido), nameof(Id))]
    public class ItensPedido
    {
        public int Id { get; set; }

        public int IdPedido { get; set; }

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }
    }
}
