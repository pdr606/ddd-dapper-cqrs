using ButecoCode.Application.Input.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButecoCode.Application.Input.Commands.PedidoContext
{
    public record InserirPedidosCommand : ICommandBase
    {
        public List<InserirPedidoCommand> _commandList { get; set; }
    }
}
