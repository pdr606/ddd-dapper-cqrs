using ButecoCode.Application.Input.Commands.PedidoContext;
using ButecoCode.Application.Input.Handlers.Interface;
using ButecoCode.Application.Repositories.PedidoContext;
using ButecoCode.Application.Repositories.Produto;
using ButecoCode.Domain.PedidoContext;

namespace ButecoCode.Application.Input.Handlers.PedidoContext
{
    public class InserirPedidoHandler(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository) : IHandlerBase<InserirPedidosCommand>
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;
        private readonly IProdutoRepository _produtoRepository = produtoRepository;

        public async void Handle(InserirPedidosCommand command)
        {
            var pedidoItens = new List<PedidoItemEntity>();
            var pedido = PedidoEntity.CriarPedido();

            foreach(var pedidoItem in command._commandList)
            {
                var precoProduto = await _produtoRepository.PegarPrecoProdutoPorId(pedidoItem.BebidaId);

                pedidoItens.Add(PedidoItemEntity.CriarPedidoItem(pedidoItem.Quantidade, pedidoItem.BebidaId)
                           .VincularPedido(pedido.Id)
                           .CalcularPrecoDoPedidoItem(precoProduto));
            }

            pedido.CalcularValorTotal(pedidoItens);

            _pedidoRepository.InserirPedidoItem(pedidoItens, pedido);
        }
    }
}
