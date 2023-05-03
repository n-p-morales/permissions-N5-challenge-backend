using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permissions_n5_challenge.Infrastructure.Persistence.Configurations.EntityConfigurations
{
    public class PermissionsTypeConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Permissions>(entity =>
            {
                entity.ToTable("PermissionsType");
            });

            builder
                .Entity<Permissions>()
                .HasKey(e => new { e.Id })
                .HasName($"PK_permissionsType");

            builder
                .Entity<Permissions>()
                .Property(e => e.Descripcion)
                .HasColumnType(SqlDataTypes.String)
                .HasColumnName("descripcion");

        }
    }
}
