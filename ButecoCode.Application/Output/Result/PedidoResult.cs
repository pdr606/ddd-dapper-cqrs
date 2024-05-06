using ButecoCode.Application.Output.DTO;
using ButecoCode.Domain.PedidoContext.DTOs;

namespace ButecoCode.Application.Output.Result
{
    public record PedidoResult
    {
        public PedidoDTO Pedido { get; set; }
        public IEnumerable<ProdutoDTO> Produtos{ get; set; }
    }
}
