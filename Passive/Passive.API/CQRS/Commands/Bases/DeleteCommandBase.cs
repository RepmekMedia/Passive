using Passive.API.CQRS.Commands.Interfaces;

namespace Passive.API.CQRS.Commands.Bases
{
    public abstract class DeleteCommandBase<TResponse> : ICommand<TResponse>
    {
    }
}
