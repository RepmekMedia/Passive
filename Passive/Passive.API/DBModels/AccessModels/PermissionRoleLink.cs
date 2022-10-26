using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class PermissionRoleLink : IBaseModel
    {
        public Guid Id { get; }

        public Guid PermissionId { get; set; }

        public Guid RoleId { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Role Role { get; set; }
    }
}
