using MediatR;

namespace Passive.API.CQRS.Commands.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
