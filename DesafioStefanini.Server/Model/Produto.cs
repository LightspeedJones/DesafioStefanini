using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioStefanini.Server.Model
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string NomeProduto { get; set; }

        public decimal Valor { get; set; }
    }
}
