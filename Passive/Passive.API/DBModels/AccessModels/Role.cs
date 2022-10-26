using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class Role : IBaseModel
    {
        public Guid Id { get; }

        public string Name { get; set; }
    }
}
