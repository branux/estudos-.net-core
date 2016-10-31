using System;
using System.Collections.Generic;

namespace CadCli.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
            this.Itens = new List<ItemPedido>();
        }

        public Guid Id { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> Itens { get; set; }
        public DateTime Data { get; set; }

    }
}
