using ButecoCode.Application.Input.Commands.Interface;

namespace ButecoCode.Application.Input.Handlers.Interface
{
    public interface IHandlerBase<in T> where T : ICommandBase
    {
        void Handle(T command);
    }
}
