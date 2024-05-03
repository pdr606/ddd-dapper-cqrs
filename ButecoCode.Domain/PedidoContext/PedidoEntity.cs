using ButecoCode.Domain.Bebida;
using ButecoCode.Domain.Common.Assertions;
using ButecoCode.Domain.Common.Entity;
using ButecoCode.Domain.Common.Interfaces;

namespace ButecoCode.Domain.PedidoContext
{
    public class PedidoEntity : BaseEntity , IAggregareRoot
    {
        public PedidoEntity(PedidoItemEntity pedidoItem)
        {
            Item = pedidoItem;
            CalcularValorTotal();
        }

        public decimal ValorTotal { get; private set; }
        public PedidoItemEntity Item { get; private set; }

        public static PedidoEntity CriarPedido(PedidoItemEntity pedidoItem)
        {
            return new PedidoEntity(pedidoItem);
        }

        public void CalcularValorTotal()
        {
            ValorTotal = Item.Quantidade * Item.Bebida.Preco;
        }
    }

    public class PedidoItemEntity : BaseEntity, IValidation
    {
        protected static decimal MIN_QUANTIDADE_PEDIDO_ITEM = 0;
        protected static decimal MAX_QUANTIDADE_PEDIDO_ITEM = 0;

        private PedidoItemEntity(short quantidade, Guid bebidaId)
        {
            Quantidade = quantidade;
            BebidaId = bebidaId;
        }

        public short Quantidade { get; private set; }
        public ProdutoEntity Bebida { get; private set; }
        public Guid BebidaId{ get; private set; }

        public static PedidoItemEntity CriarPedidoItem(short quantidade, Guid bebidaId)
        {
            return new PedidoItemEntity(quantidade, bebidaId);
        }

        public void Valildar()
        {
            Validations.ValidarSeMenorQue(MIN_QUANTIDADE_PEDIDO_ITEM, 1, "A Quantidade não pode ser menor ou igual a 0.");
        }
    }
}
