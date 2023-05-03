using System;
using permissions_n5_challenge.Domain.Entities.Permissions;
using permissions_n5_challenge.Domain.Entities.PermissionsType;
using permissions_n5_challenge.Domain.Models.PermissionsTypes;

namespace permissions_n5_challenge.Domain.Aggregates
{
	public interface IPermissionsTypeAggregate
	{
        PermissionsType PermissionsType { get; set; }

        void AddPermissionsType(PermissionsTypeModel permissionsType);

        void UpdatePermissionsType(PermissionsTypeModel permissionsType);
    }
}

