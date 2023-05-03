using System;
using permissions_n5_challenge.Domain.Entities;
using permissions_n5_challenge.Domain.Entities.Permissions;

namespace permissions_n5_challenge.Domain.Models.Permission;

public class PermissionsModel
{
	public PermissionsModel(Permissions permissions)
	{
		Id = permissions.Id;
		NombreEmpleado = permissions.NombreEmpleado;
		ApellidoEmpleado = permissions.ApellidoEmpleado;
		TipoPermiso = permissions.TipoPermiso;
		FechaPermiso = permissions.FechaPermiso;

    }

	public int Id { get; set; }
	public string NombreEmpleado { get; set; }
	public string ApellidoEmpleado { get; set; }
	public int TipoPermiso { get; set; }
	public DateTime FechaPermiso { get; set; }
}

