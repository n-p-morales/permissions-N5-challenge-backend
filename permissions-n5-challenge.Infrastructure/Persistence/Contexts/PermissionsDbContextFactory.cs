using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permissions_n5_challenge.Infrastructure.Persistence.Contexts
{
    public class PermissionsDbContextFactory : IDesignTimeDbContextFactory<PermissionsDbContext>
    {
        public PermissionsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PermissionsDbContext>();
            optionsBuilder.UseSqlServer("");

            return new PermissionsDbContext(optionsBuilder.Options);
        }
    }
}
