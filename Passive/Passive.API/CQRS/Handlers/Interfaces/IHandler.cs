using MediatR;

namespace Passive.API.CQRS.Handlers.Interfaces
{
    public interface IHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
