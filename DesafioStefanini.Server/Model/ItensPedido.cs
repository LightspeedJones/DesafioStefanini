

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioStefanini.Server.Model
{
    //[PrimaryKey(nameof(IdPedido), nameof(Id))]
    public class ItensPedido
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public int IdPedido { get; set; }

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }

        [JsonIgnore]
        public virtual Pedido? Pedido { get; set; }

        //[JsonIgnore]
        //public virtual Pedido? Pedido { get; set; }

        //[JsonIgnore]
        //public virtual Produto? Produto { get; set; }
    }
}
