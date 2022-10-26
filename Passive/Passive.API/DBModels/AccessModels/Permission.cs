using JSLibrary.Logics.Interfaces;
using Passive.API.DBModels.AccessModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class Permission : IPermission
    {
        public Guid Id { get; }

        public string Name { get; set; }
    }
}
