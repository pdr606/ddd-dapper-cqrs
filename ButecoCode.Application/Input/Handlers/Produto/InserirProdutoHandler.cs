using ButecoCode.Application.Input.Commands.Produto;
using ButecoCode.Application.Input.Handlers.Interface;
using ButecoCode.Application.Repositories.Produto;
using ButecoCode.Domain.Bebida;

namespace ButecoCode.Application.Input.Handlers.Produto
{
    public class InserirProdutoHandler : IHandlerBase<InserirProdutoCommand>
    {

        private readonly IProdutoRepository _produtoRepository;

        public InserirProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Handle(InserirProdutoCommand command)
        {
            var produto = ProdutoEntity.CriarProduto(command.Nome, command.Preco);

            _produtoRepository.InserirProduto(produto);
        }
    }
}
