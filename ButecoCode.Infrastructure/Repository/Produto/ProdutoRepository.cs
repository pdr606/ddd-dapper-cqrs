using ButecoCode.Application.Output.DTO;
using ButecoCode.Application.Output.Mapper;
using ButecoCode.Application.Repositories.Produto;
using ButecoCode.Domain.Bebida;
using ButecoCode.Infrastructure.Factory;
using ButecoCode.Infrastructure.Queries;
using Dapper;
using System.Data;

namespace ButecoCode.Infrastructure.Repository.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _connection = SqlFactory.PostgresConnection();

        public void InserirProduto(ProdutoEntity entity)
        {
            var query = ProdutoQueries.InserirProduto(entity);

            using (_connection)
            {
                _connection.Execute(query.query, query.parameters);
            }
        }

        public async Task<IEnumerable<ProdutoDTO>> PegarTodosProdutosAsync()
        {
            var query = ProdutoQueries.BuscarTodosProdutos();
            List<ProdutoEntity> produtos;

            using (_connection)
            {
                produtos = (await _connection.QueryAsync<ProdutoEntity>(query.query)).ToList();
            }

            return produtos.Select(EntityMapper.ToDTO);
        }

        public async Task<decimal> PegarPrecoProdutoPorId(Guid id)
        {
            var query = ProdutoQueries.BuscarPrecoProdutoPorId(id);

            using (_connection)
            {
                var preco = (await _connection.QueryFirstOrDefaultAsync<decimal>(query.query, query.parameters));
                return preco;
            }
        }
    }
}
