using Passive.API.BusinessLogics.Bases;
using Passive.API.DBContexts;
using Passive.API.DBModels.AccessModels;

namespace Passive.API.BusinessLogics.AccessDBBusinessLogics
{
    public class PermissionBusinessLogic : AccessDBBusinessLogicBase<Permission>
    {
        public PermissionBusinessLogic(AccessContext DBContext) : base(DBContext)
        {
        }

        public override void Add(Permission model)
        {
            base.Add(model);
        }

        public override Task AddAsync(Permission model, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(model, cancellationToken);
        }

        public override void Delete(Permission model)
        {
            base.Delete(model);
        }

        public override Task DeleteAsync(Permission model, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(model, cancellationToken);
        }

        public override Permission Get(Guid id)
        {
            return base.Get(id);
        }

        public override Task<Permission> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return base.GetAsync(id, cancellationToken);
        }

        public override IQueryable<Permission> Load()
        {
            return base.Load();
        }

        public override Task<IQueryable<Permission>> LoadAsync(CancellationToken cancellationToken = default)
        {
            return base.LoadAsync(cancellationToken);
        }

        public override void Update(Permission model)
        {
            base.Update(model);
        }

        public override Task UpdateAsync(Permission model, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(model, cancellationToken);
        }
    }
}
