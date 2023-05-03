using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permissions_n5_challenge.Infrastructure.Persistence.Contexts
{
    public class PermissionsDbContext : DbContext, IPermissionsDbContext
    {
        public PermissionsDbContext(
            DbContextOptions<PermissionsDbContext> options
            ): base(options)
        {
        }

        public DbSet<Permissions> Permissions { get; set; }

        public DbSet<PermissionsType> PermissionsType { get; set; }

        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public void BeginTransactionAsync(CancellationToken cancellationToken)
        {
            Database.BeginTransactionAsync(cancellationToken);
        }

        public void CommitTransaction()
        {
            Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            Database.RollbackTransaction();
        }

        public void TrackEntityChanges()
        {
            var newEntities = ChangeTracker
                .Entries<IAuditableEntity>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);

            var modifiedEntities = ChangeTracker
                .Entries<IAuditableEntity>()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity);

            var now = DateTime.UtcNow;

            foreach (var added in newEntities)
            {
                added.Created = now;
                added.LastModified = now;
            }

            foreach (var modified in modifiedEntities)
            {
                modified.LastModified = now;
            }
        }

        public override int SaveChanges()
        {
            TrackEntityChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            TrackEntityChanges();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Permissions.Configure(modelBuilder);
            PermissionsType.Configure(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

    }
}
