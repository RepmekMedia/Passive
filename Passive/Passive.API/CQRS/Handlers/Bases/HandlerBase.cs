using JSLibrary.Logics.Business.Interfaces;
using JSLibrary.Logics.Interfaces;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;
using Passive.API.CQRS.Handlers.Interfaces;

namespace Passive.API.CQRS.Handlers.Bases
{
    public abstract class HandlerBase<TModel, TModelKey, TRequest, TResponse> : IHandler<TRequest, TResponse> where TModel : class, IIdentifierModel<TModelKey> where TRequest : IRequest<TResponse> where TModelKey : IEquatable<TModelKey>
    {
        protected HandlerBase(ILogger logger, IBusinessLogicBase<TModel, TModelKey, DbContext> businessLogicBase)
        {
            this.Logger = logger;
            this.BusinessLogicBase = businessLogicBase;
        }

        protected ILogger Logger { get; init; }

        protected IBusinessLogicBase<TModel, TModelKey, DbContext> BusinessLogicBase { get; init; }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
