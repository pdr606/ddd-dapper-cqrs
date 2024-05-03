using ButecoCode.Application.Input.Commands.Interface;

namespace ButecoCode.Application.Input.Commands.Produto
{
    public record InserirProdutoCommand : ICommandBase
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
