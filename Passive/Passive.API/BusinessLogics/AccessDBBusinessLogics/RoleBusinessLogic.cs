using Passive.API.BusinessLogics.Bases;
using Passive.API.DBContexts;
using Passive.API.DBModels.AccessModels;

namespace Passive.API.BusinessLogics.AccessDBBusinessLogics
{
    public class RoleBusinessLogic : AccessDBBusinessLogicBase<Role>
    {
        public RoleBusinessLogic(AccessContext DBContext) : base(DBContext)
        {
        }

        public override void Add(Role model)
        {
            base.Add(model);
        }

        public override Task AddAsync(Role model, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(model, cancellationToken);
        }

        public override void Delete(Role model)
        {
            base.Delete(model);
        }

        public override Task DeleteAsync(Role model, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(model, cancellationToken);
        }

        public override Role Get(Guid id)
        {
            return base.Get(id);
        }

        public override Task<Role> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return base.GetAsync(id, cancellationToken);
        }

        public override IQueryable<Role> Load()
        {
            return base.Load();
        }

        public override Task<IQueryable<Role>> LoadAsync(CancellationToken cancellationToken = default)
        {
            return base.LoadAsync(cancellationToken);
        }

        public override void Update(Role model)
        {
            base.Update(model);
        }

        public override Task UpdateAsync(Role model, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(model, cancellationToken);
        }
    }
}
