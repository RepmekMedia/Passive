using JSLibrary.Logics.Interfaces;
using Passive.API.DBModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class User : IBaseModel
    {
        public Guid Id { get; }
    }
}
