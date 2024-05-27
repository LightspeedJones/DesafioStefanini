using System.ComponentModel.DataAnnotations;

namespace DesafioStefanini.Server.Model
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public string NomeCliente { get; set; }

        public string EmailCliente { get; set; }

        public DateTime DataCriacao { get; set; }

        public int ValorTotal { get; set; }

        public bool Pago { get; set; }

        //public virtual IEnumerable<ItensPedido> Itens { get; set; }
        public virtual IEnumerable<ItensPedido> ItensPedido { get; set; }
    }
}
