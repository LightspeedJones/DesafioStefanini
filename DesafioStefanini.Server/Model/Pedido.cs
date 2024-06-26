﻿using System.ComponentModel.DataAnnotations;

namespace DesafioStefanini.Server.Model
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public string NomeCliente { get; set; }

        public string EmailCliente { get; set; }

        public DateTime DataCriacao { get; set; }

        public bool Pago { get; set; }

        public virtual ICollection<ItensPedido> ItensPedido { get; set; }
    }
}
