using JSLibrary.Logics.Interfaces;
using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class Permission : IBaseModel
    {
        public Guid Id { get; }

        public string Name { get; set; }
    }
}
