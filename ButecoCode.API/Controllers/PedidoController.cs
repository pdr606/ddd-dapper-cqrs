using ButecoCode.Application.Input.Commands.PedidoContext;
using ButecoCode.Application.Input.Commands.Produto;
using ButecoCode.Application.Input.Handlers.PedidoContext;
using ButecoCode.Application.Input.Handlers.Produto;
using ButecoCode.Application.Output.DTO;
using ButecoCode.Application.Output.Result;
using ButecoCode.Application.Repositories.PedidoContext;
using ButecoCode.Application.Repositories.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ButecoCode.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PedidoController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public void SalvarProduto([FromServices] InserirPedidoHandler handler, [FromBody] InserirPedidosCommand command)
        {
            handler.Handle(command);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<PedidoResult> BuscarPedidoPorId([FromServices] IPedidoRepository repository, [FromRoute] Guid id)
        {
            return await repository.BuscarPedidoPorIdComProdutos(id);
        }
    }
}
