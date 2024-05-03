using ButecoCode.Application.Input.Commands.Produto;
using ButecoCode.Application.Input.Handlers.Produto;
using ButecoCode.Application.Output.DTO;
using ButecoCode.Application.Repositories.Produto;
using ButecoCode.Domain.Bebida;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ButecoCode.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        public void SalvarProduto([FromServices] InserirProdutoHandler handler, [FromBody] InserirProdutoCommand command)
        {
            handler.Handle(command);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> BuscarTodosProdutos([FromServices] IProdutoRepository repository)
        {
            return await repository.PegarTodosProdutosAsync();
        }
    }
}
