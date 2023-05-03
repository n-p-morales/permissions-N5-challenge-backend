using System;
namespace permissions_n5_challenge.Domain.Entities.PermissionsType
{
	public class PermissionsType
	{
        public PermissionsType(string descripcion)
        {
            Descripcion = descripcion;
           
        }

        public int Id { get; internal set; }
        public string Descripcion { get; internal set; }

        public static PermissionsType Create(string descripcion)
        {
            return new PermissionsType(descripcion);
        }
    }
}

