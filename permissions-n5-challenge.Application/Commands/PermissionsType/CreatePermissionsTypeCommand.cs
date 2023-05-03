using System;
using FluentValidation;
using MediatR;
using permissions_n5_challenge.Domain.Aggregates;
using permissions_n5_challenge.Domain.Contexts;
using permissions_n5_challenge.Domain.Models.PermissionsTypes;

namespace permissions_n5_challenge.Application.Commands.PermissionsType
{
	public class CreatePermissionsTypeCommand : IRequest<PermissionsTypeModel>
	{
		public CreatePermissionsTypeCommand(PermissionsTypeModel permissionsType)
		{
			PermissionsType = permissionsType;
		}

		public PermissionsTypeModel PermissionsType { get; set; }
	}

	public class CreatePermissionsTypeCommandHandler : IRequestHandler<CreatePermissionsTypeCommand, PermissionsTypeModel>
    {
		private readonly IValidator<CreatePermissionsTypeCommand> validator;
		private readonly IPermissionsDbContext context;
		private readonly IPermissionsTypeAggregate permissionsTypeAggregate;

		public CreatePermissionsTypeCommandHandler(
			IValidator<CreatePermissionsTypeCommand> validator,
			IPermissionsDbContext context,
			IPermissionsTypeAggregate permissionsTypeAggregate
			)
        {
			this.validator = validator;
			this.context = context;
			this.permissionsTypeAggregate = permissionsTypeAggregate;
		}

		public async Task<PermissionsTypeModel> Handle(CreatePermissionsTypeCommand request, CancellationToken cancellationToken)
		{
			await validator.ValidateAndThrowAsync(request);

			using (context)
			{
				permissionsTypeAggregate.AddPermissionsType(request.PermissionsType);
				try
				{
					await context.PermissionsType.AddAsync(permissionsTypeAggregate.PermissionsType);
					await context.SaveChangesAsync(cancellationToken);
				}
				catch (Exception ex)
				{
					throw new ArgumentException($"An error ocurred while inserting the entity {permissionsTypeAggregate.PermissionsType.Id}.", ex);
				}
			}

			return request.PermissionsType;
		}
	}

	public class CreatePermissionsTypeCommandValidator : AbstractValidator<CreatePermissionsTypeCommand>
	{
		public CreatePermissionsTypeCommandValidator()
		{
			RuleFor(a => a.PermissionsType).NotNull().WithMessage("PermissionsType must not be null");
			RuleFor(a => a.PermissionsType.Descripcion).NotEmpty().NotNull();
		}
	}
}

