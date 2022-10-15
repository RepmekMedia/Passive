using MediatR;

namespace Passive.API.CQRS.Queries.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
