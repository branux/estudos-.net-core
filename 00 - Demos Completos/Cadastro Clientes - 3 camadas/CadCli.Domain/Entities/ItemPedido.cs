using System;

namespace CadCli.Domain.Entities
{
    public class ItemPedido
    {
        public Guid Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public Guid PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public decimal Valor { get; set; }
    }
}
