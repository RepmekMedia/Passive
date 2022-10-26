using JSLibrary.Logics.Business;
using JSLibrary.Logics.Interfaces;
using Passive.API.DBContexts;

namespace Passive.API.BusinessLogics.Bases
{
    public abstract class AccessDBBusinessLogicBase<TModel> : BusinessLogicBase<TModel, Guid, AccessContext> where TModel : class, IIdentifierModel<Guid>
    {
        protected AccessDBBusinessLogicBase(AccessContext DBContext) : base(DBContext)
        {
        }
    }
}
