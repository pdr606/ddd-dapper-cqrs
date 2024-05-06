using ButecoCode.Application.Output.DTO;
using ButecoCode.Application.Output.Result;
using ButecoCode.Application.Repositories.PedidoContext;
using ButecoCode.Domain.Bebida;
using ButecoCode.Domain.PedidoContext;
using ButecoCode.Domain.PedidoContext.DTOs;
using ButecoCode.Infrastructure.Factory;
using ButecoCode.Infrastructure.Queries;
using Dapper;
using System.Data;

namespace ButecoCode.Infrastructure.Repository.Produto
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnection _connection = SqlFactory.PostgresConnection();

        public void InserirPedidoItem(List<PedidoItemEntity> pedidoItems, PedidoEntity pedido)
        {
            using(_connection)
            {
                foreach (var pedidoItem in pedidoItems)
                {
                    var queryPedidoItem = PedidoQueries.InserirPedidoItem(pedidoItem);
                    _connection.Execute(queryPedidoItem.query, queryPedidoItem.parameters);
                }

                var queryPedido = PedidoQueries.InserirPedido(pedido);
                _connection.Execute(queryPedido.query, queryPedido.parameters);
            }
        }

        public async Task<PedidoResult> BuscarPedidoPorIdComProdutos(Guid id)
        {
            var pedidoResult = new PedidoResult();
            var listProdutosDto = new List<ProdutoDTO>();

            using (_connection)
            {
                var queryPedido = PedidoQueries.BuscarPedidoPorId(id);
                pedidoResult.Pedido = await _connection.QueryFirstOrDefaultAsync<PedidoDTO>(queryPedido.query, queryPedido.parameters);

                var queryPedidoItem = PedidoQueries.BuscarPedidoItemPorIdPedido(id);

                var itemsPedido = await _connection.QueryAsync<PedidoItemEntity>(queryPedidoItem.query, queryPedidoItem.parameters);

                foreach(var item in itemsPedido)
                {
                    var queryProduto = ProdutoQueries.BuscarProdutoPorId(item.BebidaId);
                    var produto = await _connection.QueryFirstOrDefaultAsync<ProdutoEntity>(queryProduto.query, queryProduto.parameters);

                    listProdutosDto.Add(new ProdutoDTO(produto.Id, produto.Nome, produto.Preco, item.Quantidade));
                }
            }

            pedidoResult.Produtos = listProdutosDto;

            return pedidoResult;
        }
    }
}
