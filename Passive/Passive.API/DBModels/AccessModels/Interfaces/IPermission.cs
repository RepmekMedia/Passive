using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels.Interfaces
{
    public interface IPermission : IBaseModel
    {
        string Name { get; set; }
    }
}
