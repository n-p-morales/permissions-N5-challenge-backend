using System;
namespace permissions_n5_challenge.Domain.Entities.Permissions
{
	public class Permissions
	{
        public Permissions() { }
		public Permissions(string nombreEmpleado, string apellidoEmpleado, int tipoPermiso, DateTime fechaPermiso)
        {
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado = apellidoEmpleado;
            TipoPermiso = tipoPermiso;
            FechaPermiso = fechaPermiso;
		}

        public int Id { get; internal set; }
        public string NombreEmpleado { get; internal set; }
        public string ApellidoEmpleado { get; internal set; }
        public int TipoPermiso { get; internal set; }
        public DateTime FechaPermiso { get; internal set; }

        public static Permissions Create(string nombreEmpleado, string apellidoEmpleado, int tipoPermiso, DateTime fechaPermiso)
        {
            return new Permissions(nombreEmpleado, apellidoEmpleado, tipoPermiso, fechaPermiso);
        }
    }
}

