using System;
using permissions_n5_challenge.Domain.Entities.PermissionsType;

namespace permissions_n5_challenge.Domain.Models.PermissionsTypes
{
	public class PermissionsTypeModel
	{
		public PermissionsTypeModel(PermissionsType permissionsType)
		{
			Id = permissionsType.Id;
			Descripcion = permissionsType.Descripcion;
		}

        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}

