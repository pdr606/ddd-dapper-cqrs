using ButecoCode.Domain.Bebida;
using ButecoCode.Domain.Common.Assertions;
using ButecoCode.Domain.Common.Entity;
using ButecoCode.Domain.Common.Interfaces;

namespace ButecoCode.Domain.PedidoContext
{
    public class PedidoEntity : BaseEntity , IAggregareRoot
    {

        protected PedidoEntity() { }
        
        public decimal ValorTotal { get; private set; }

        public void CalcularValorTotal(List<PedidoItemEntity> items)
        {
            foreach(var item in items)
            {
                ValorTotal += item.Preco;
            }
        }

        public static PedidoEntity CriarPedido()
        {
            return new PedidoEntity();
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

        protected PedidoItemEntity() { }

        public short Quantidade { get; private set; }
        public decimal Preco { get; private set; }
        public Guid BebidaId{ get; private set; }
        public Guid PedidoId { get; private set; }

        public static PedidoItemEntity CriarPedidoItem(short quantidade, Guid bebidaId)
        {
            return new PedidoItemEntity(quantidade, bebidaId);
        }

        public PedidoItemEntity VincularPedido(Guid pedidoId)
        {
            this.PedidoId = pedidoId; return this;
        }

        public PedidoItemEntity CalcularPrecoDoPedidoItem(decimal precoBebida)
        {
            this.Preco = precoBebida * Quantidade; return this;
        }

        public void Valildar()
        {
            Validations.ValidarSeMenorQue(MIN_QUANTIDADE_PEDIDO_ITEM, 1, "A Quantidade não pode ser menor ou igual a 0.");
        }
    }
}
