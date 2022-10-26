using Microsoft.EntityFrameworkCore;

namespace Passive.API.DBContexts
{
    public partial class AccessContext : DbContext
    {
        public AccessContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
