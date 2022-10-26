using Passive.API.DBModels.AccessModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class Role : IRole
    {
        public Guid Id { get; }

        public string Name { get; set; }
    }
}
