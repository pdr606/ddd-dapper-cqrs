using ButecoCode.Application.Output.DTO;
using ButecoCode.Domain.Bebida;

namespace ButecoCode.Application.Repositories.Produto
{
    public interface IProdutoRepository
    {
        void InserirProduto(ProdutoEntity entity);
        Task<IEnumerable<ProdutoDTO>> PegarTodosProdutosAsync();
    }
}
