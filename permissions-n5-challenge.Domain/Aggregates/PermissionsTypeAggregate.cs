using System;
using permissions_n5_challenge.Domain.Entities.PermissionsType;
using permissions_n5_challenge.Domain.Models.PermissionsTypes;
using permissions_n5_challenge.Domain.Commons.EntityBase;

namespace permissions_n5_challenge.Domain.Aggregates
{
	public class PermissionsTypeAggregate: Aggregate, IPermissionsTypeAggregate
	{
		public PermissionsTypeAggregate()
		{
		}

        public PermissionsType PermissionsType { get; set; }

        public void AddPermissionsType(PermissionsTypeModel permissionType)
        {
            PermissionsType = PermissionsType.Create(permissionType.Descripcion);
        }

        public void UpdatePermissionsType(PermissionsTypeModel permissionsType)
        {
            PermissionsType = PermissionsType.Create(permissionsType.Descripcion);
        }
    }
}

