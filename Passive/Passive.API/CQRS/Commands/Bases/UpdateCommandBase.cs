using Passive.API.CQRS.Commands.Interfaces;

namespace Passive.API.CQRS.Commands.Bases
{
    public abstract class UpdateCommandBase<TResponse> : ICommand<TResponse>
    {
    }
}
