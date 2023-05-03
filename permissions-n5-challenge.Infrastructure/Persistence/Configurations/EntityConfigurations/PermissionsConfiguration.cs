using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permissions_n5_challenge.Infrastructure.Persistence.Configurations.EntityConfigurations
{
    public class PermissionsConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Permissions>(entity =>
            {
                entity.ToTable("Permissions");
            });

            builder
                .Entity<Permissions>()
                .HasKey(e => new { e.Id })
                .HasName($"PK_permissions");

            builder
                .Entity<Permissions>()
                .Property(e => e.NombreEmpleado)
                .HasColumnType(SqlDataTypes.String)
                .HasColumnName("nombreEmpleado");

            builder
                .Entity<Permissions>()
                .Property(e => e.ApellidoEmpleado)
                .HasColumnType(SqlDataTypes.String)
                .HasColumnName("apellidoEmpleado");

            builder
                .Entity<Permissions>()
                .Property(e => e.TipoPermiso)
                .HasColumnType(SqlDataTypes.Int)
                .HasColumnName("tipoPermiso");

            builder
               .Entity<Permissions>()
               .Property(e => e.FechaPermiso)
               .HasColumnType(SqlDataTypes.DateTime)
               .HasColumnName("fechaPermiso");
        }
    }
}
