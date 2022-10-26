using JSLibrary.Logics.Interfaces;
using Passive.API.DBModels.AccessModels.Interfaces;

namespace Passive.API.DBModels.AccessModels
{
    public class User : IUser
    {
        public Guid Id { get; }
    }
}
