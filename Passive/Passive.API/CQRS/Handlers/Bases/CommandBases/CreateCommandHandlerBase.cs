using JSLibrary.Logics.Business.Interfaces;
using JSLibrary.Logics.Interfaces;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace Passive.API.CQRS.Handlers.Bases.CommandBases
{
    public abstract class CreateCommandHandlerBase<TModel, TModelKey, TRequest, TResponse> : HandlerBase<TModel, TModelKey, TRequest, TResponse> where TModel : class, IIdentifierModel<TModelKey> where TRequest : IRequest<TResponse> where TModelKey : IEquatable<TModelKey>
    {
        public CreateCommandHandlerBase(ILogger<HandlerBase> logger, IBusinessLogicBase<TModel, TModelKey, DbContext> businessLogicBase) : base(logger, businessLogicBase)
        {
        }
    }
}
