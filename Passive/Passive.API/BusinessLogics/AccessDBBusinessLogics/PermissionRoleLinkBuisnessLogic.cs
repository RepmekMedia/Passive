using Passive.API.BusinessLogics.Bases;
using Passive.API.DBContexts;
using Passive.API.DBModels.AccessModels;

namespace Passive.API.BusinessLogics.AccessDBBusinessLogics
{
    public class PermissionRoleLinkBuisnessLogic : AccessDBBusinessLogicBase<PermissionRoleLink>
    {
        public PermissionRoleLinkBuisnessLogic(AccessContext DBContext) : base(DBContext)
        {
        }

        public override void Add(PermissionRoleLink model)
        {
            base.Add(model);
        }

        public override Task AddAsync(PermissionRoleLink model, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(model, cancellationToken);
        }

        public override void Delete(PermissionRoleLink model)
        {
            base.Delete(model);
        }

        public override Task DeleteAsync(PermissionRoleLink model, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(model, cancellationToken);
        }

        public override PermissionRoleLink Get(Guid id)
        {
            return base.Get(id);
        }

        public override Task<PermissionRoleLink> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return base.GetAsync(id, cancellationToken);
        }

        public override IQueryable<PermissionRoleLink> Load()
        {
            return base.Load();
        }

        public override Task<IQueryable<PermissionRoleLink>> LoadAsync(CancellationToken cancellationToken = default)
        {
            return base.LoadAsync(cancellationToken);
        }

        public override void Update(PermissionRoleLink model)
        {
            base.Update(model);
        }

        public override Task UpdateAsync(PermissionRoleLink model, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(model, cancellationToken);
        }
    }
}
