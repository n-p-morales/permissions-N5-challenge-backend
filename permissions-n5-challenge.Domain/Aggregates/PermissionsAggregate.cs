using System;
using System.Security;
using permissions_n5_challenge.Domain.Entities.Permissions;
using permissions_n5_challenge.Domain.Models.Permission;
using permissions_n5_challenge.Domain.Commons.EntityBase;

namespace permissions_n5_challenge.Domain.Aggregates
{
	public class PermissionsAggregate: Aggregate, IPermissionsAggregate
	{
		public PermissionsAggregate()
		{
		}

		public Permissions Permissions { get; set; }

		public void AddPermissions(PermissionsModel permission)
		{
			Permissions = Permissions.Create(permission.NombreEmpleado, permission.ApellidoEmpleado, permission.TipoPermiso, permission.FechaPermiso);
		}

		public void UpdatePermissions(PermissionsModel permissions)
        {
            Permissions = Permissions.Create(permissions.NombreEmpleado, permissions.ApellidoEmpleado, permissions.TipoPermiso, permissions.FechaPermiso);
        }
    }
}

