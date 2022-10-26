using Passive.API.BusinessLogics.Bases;
using Passive.API.DBContexts;
using Passive.API.DBModels.AccessModels;

namespace Passive.API.BusinessLogics.AccessDBBusinessLogics
{
    public class UserBusinessLogic : AccessDBBusinessLogicBase<User>
    {
        public UserBusinessLogic(AccessContext DBContext) : base(DBContext)
        {
        }

        public override void Add(User model)
        {
            base.Add(model);
        }

        public override Task AddAsync(User model, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(model, cancellationToken);
        }

        public override void Delete(User model)
        {
            base.Delete(model);
        }

        public override Task DeleteAsync(User model, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(model, cancellationToken);
        }

        public override User Get(Guid id)
        {
            return base.Get(id);
        }

        public override Task<User> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return base.GetAsync(id, cancellationToken);
        }

        public override IQueryable<User> Load()
        {
            return base.Load();
        }

        public override Task<IQueryable<User>> LoadAsync(CancellationToken cancellationToken = default)
        {
            return base.LoadAsync(cancellationToken);
        }

        public override void Update(User model)
        {
            base.Update(model);
        }

        public override Task UpdateAsync(User model, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(model, cancellationToken);
        }
    }
}
