using Microsoft.EntityFrameworkCore;

namespace Passive.API.DBContexts
{
    public class AccessContext : DbContext
    {
        public AccessContext(DbContextOptions options) : base(options)
        {
        }
    }
}
