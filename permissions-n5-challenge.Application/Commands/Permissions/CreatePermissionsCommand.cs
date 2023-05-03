using System;
using FluentValidation;
using MediatR;
using permissions_n5_challenge.Domain.Aggregates;
using permissions_n5_challenge.Domain.Contexts;
using permissions_n5_challenge.Domain.Models.Permission;

namespace permissions_n5_challenge.Application.Commands.Permissions
{
	public class CreatePermissionsCommand : IRequest<PermissionsModel>
	{
		public CreatePermissionsCommand(PermissionsModel permissions)
		{
			Permissions = permissions;
		}

		public PermissionsModel Permissions { get; set; }
	}

	public class CreatePermissionsCommandHandler : IRequestHandler<CreatePermissionsCommand, PermissionsModel>
    {
		private readonly IValidator<CreatePermissionsCommand> validator;
		private readonly IPermissionsDbContext context;
		private readonly IPermissionsAggregate permissionsAggregate;

		public CreatePermissionsCommandHandler(
			IValidator<CreatePermissionsCommand> validator,
			IPermissionsDbContext context,
			IPermissionsAggregate permissionsAggregate
            )
		{
			this.validator = validator;
			this.context = context;
			this.permissionsAggregate = permissionsAggregate;
		}

		public async Task<PermissionsModel> Handle(CreatePermissionsCommand request, CancellationToken cancellationToken)
        {
			await validator.ValidateAndThrowAsync(request);

			using (context)
            {
				permissionsAggregate.AddPermissions(request.Permissions);
				try
                {
					await context.Permissions.AddAsync(permissionsAggregate.Permissions);
					await context.SaveChangesAsync(cancellationToken);
                }
				catch(Exception ex)
                {
					throw new ArgumentException($"An error ocurred while inserting the entity {permissionsAggregate.Permissions.Id}.", ex);
				}
            }

			return request.Permissions;
        }
    }

	public class CreatePermissionsCommandValidator : AbstractValidator<CreatePermissionsCommand>
    {
		public CreatePermissionsCommandValidator()
        {
			RuleFor(a => a.Permissions).NotNull().WithMessage("Permissions must not be null");
			RuleFor(a => a.Permissions.NombreEmpleado).NotEmpty().NotNull();
			RuleFor(a => a.Permissions.ApellidoEmpleado).NotEmpty().NotNull();
			RuleFor(a => a.Permissions.TipoPermiso).GreaterThan(0).WithMessage("Tipo permiso must be greater than zero");
		}
    }
}

