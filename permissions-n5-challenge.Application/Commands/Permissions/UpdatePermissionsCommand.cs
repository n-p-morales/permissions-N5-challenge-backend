using System;
using FluentValidation;
using MediatR;
using permissions_n5_challenge.Domain.Aggregates;
using permissions_n5_challenge.Domain.Contexts;
using permissions_n5_challenge.Domain.Models.Permission;
using permissions_n5_challenge.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;

namespace permissions_n5_challenge.Application.Commands.Permissions
{
	public class UpdatePermissionsCommand: IRequest<PermissionsModel>
	{
		public UpdatePermissionsCommand(PermissionsModel permissionsModel)
		{
			Permissions = permissionsModel;
		}

		public PermissionsModel Permissions { get; set; }
	}

	public class UpdatePermissionsCommandHandler: IRequestHandler<UpdatePermissionsCommand, PermissionsModel>
    {
		private readonly IValidator<CreatePermissionsCommand> validator;
		private readonly IPermissionsDbContext context;
		private readonly IPermissionsAggregate permissionsAggregate;

		public UpdatePermissionsCommandHandler(
			IValidator<CreatePermissionsCommand> validator,
			IPermissionsDbContext context,
			IPermissionsAggregate permissionsAggregate
			)
        {
			this.validator = validator;
			this.context = context;
			this.permissionsAggregate = permissionsAggregate;
		}

		public async Task<PermissionsModel> Handle(UpdatePermissionsCommand request, CancellationToken cancellationToken)
		{
			await validator.ValidateAndThrowAsync(request);

			using (context)
			{
				if(DidThePermissionsChange(request))
                {
					permissionsAggregate.UpdatePermissions(request.Permissions);
					try
					{
						 context.Permissions.Update(permissionsAggregate.Permissions);
						 context.SaveChanges();
					}
					catch (Exception ex)
					{
						throw new ArgumentException($"An error ocurred while updating the entity {permissionsAggregate.Permissions.Id}.", ex);
					}
				}
			}

			return request.Permissions;
		}

		private bool DidThePermissionsChange(UpdatePermissionsCommand request)
        {
			var currentPermissions = context.Permissions
				.AsNoTracking()
				.SingleOrDefault(s => s.Id == request.Permissions.Id);

			if(currentPermissions != null && (currentPermissions.NombreEmpleado != request.Permissions.NombreEmpleado ||
				currentPermissions.ApellidoEmpleado != request.Permissions.ApellidoEmpleado || currentPermissions.TipoPermiso != request.Permissions.TipoPermiso))
            {
				return true;
            }
			return false;
        }
	}

	public class UpdatePermissionsCommandValidator : AbstractValidator<UpdatePermissionsCommand>
    {
		public UpdatePermissionsCommandValidator()
        {
			RuleFor(a => a.Permissions.Id).GreaterThan(0);
			RuleFor(a => a.Permissions.NombreEmpleado).NotEmpty().NotNull();
			RuleFor(a => a.Permissions.ApellidoEmpleado).NotEmpty().NotNull();
			RuleFor(a => a.Permissions.TipoPermiso).GreaterThan(0).WithMessage("Tipo permiso must be greater than zero");
		}
    }
}

