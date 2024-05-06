using ButecoCode.Application.Output.Result;
using ButecoCode.Domain.PedidoContext;

namespace ButecoCode.Application.Repositories.PedidoContext
{
    public interface IPedidoRepository
    {
        void InserirPedidoItem(List<PedidoItemEntity> pedidoItems, PedidoEntity pedido);
        Task<PedidoResult> BuscarPedidoPorIdComProdutos(Guid id);
    }
}
