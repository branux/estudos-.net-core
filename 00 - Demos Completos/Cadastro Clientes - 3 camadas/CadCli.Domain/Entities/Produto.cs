using System;
using System.Collections.Generic;

namespace CadCli.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            this.ItensPedidos = new List<ItemPedido>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Fabricacao { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }
    }
}
