using System;
using Microsoft.EntityFrameworkCore;
using permissions_n5_challenge.Domain.Entities.Permissions;
using permissions_n5_challenge.Domain.Entities.PermissionsType;

namespace permissions_n5_challenge.Domain.Contexts
{
	public interface IPermissionsDbContext : IDisposable
	{
		DbSet<Permissions> Permissions { get; set; }

		DbSet<PermissionsType> PermissionsType { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);

		void BeginTransaction();

		void BeginTransactionAsync(CancellationToken cancellationToken);

		void CommitTransaction();

		void RollbackTranscation();

		int SaveChanges();

		void TrackEntityChanges();
	}
}

