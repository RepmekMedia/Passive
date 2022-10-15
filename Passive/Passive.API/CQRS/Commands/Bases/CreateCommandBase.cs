using Passive.API.CQRS.Commands.Interfaces;

namespace Passive.API.CQRS.Commands.Bases
{
    public abstract class CreateCommandBase<TResponse> : ICommand<TResponse>
    {
    }
}
