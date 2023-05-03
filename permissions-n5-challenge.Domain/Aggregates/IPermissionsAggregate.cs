using System;
using permissions_n5_challenge.Domain.Entities.Permissions;
using permissions_n5_challenge.Domain.Models.Permission;

namespace permissions_n5_challenge.Domain.Aggregates
{
	public interface IPermissionsAggregate
	{
		Permissions Permissions { get; set; }

		void AddPermissions(PermissionsModel permissions);

		void UpdatePermissions(PermissionsModel permissions);
	}
}

