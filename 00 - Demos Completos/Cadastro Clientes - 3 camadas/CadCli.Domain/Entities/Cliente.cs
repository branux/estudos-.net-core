using System;
using System.Collections.Generic;

namespace CadCli.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            this.Pedidos = new List<Pedido>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
