using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels.Interfaces
{
    public interface IRole : IBaseModel
    {
        string Name { get; set; }
    }
}
