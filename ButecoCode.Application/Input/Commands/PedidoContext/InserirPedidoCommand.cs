using ButecoCode.Application.Input.Commands.Interface;

namespace ButecoCode.Application.Input.Commands.PedidoContext
{
    public record InserirPedidoCommand : ICommandBase
    {
        public short Quantidade { get; set; }
        public Guid BebidaId { get; set; }
    }
}
