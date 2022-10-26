using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class RoleUserLink : IBaseModel
    {
        public Guid Id { get; }

        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
