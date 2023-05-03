using System;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using permissions_n5_challenge.Domain.Aggregates;
using permissions_n5_challenge.Domain.Contexts;
using permissions_n5_challenge.Domain.Models.PermissionsTypes;

namespace permissions_n5_challenge.Application.Commands.PermissionsType
{
	public class UpdatePermissionsTypeCommand : IRequest<PermissionsTypeModel>
	{
		public UpdatePermissionsTypeCommand(PermissionsTypeModel permissionsTypeModel)
		{
			PermissionsType = permissionsTypeModel;
		}

		public PermissionsTypeModel PermissionsType { get; set; }
	}

	public class UpdatePermissionsCommandHandler : IRequestHandler<UpdatePermissionsTypeCommand, PermissionsTypeModel>
	{
		private readonly IValidator<CreatePermissionsTypeCommand> validator;
		private readonly IPermissionsDbContext context;
		private readonly IPermissionsTypeAggregate permissionsTypeAggregate;

		public UpdatePermissionsCommandHandler(
			IValidator<CreatePermissionsTypeCommand> validator,
			IPermissionsDbContext context,
			IPermissionsTypeAggregate permissionsTypeAggregate
			)
		{
			this.validator = validator;
			this.context = context;
			this.permissionsTypeAggregate = permissionsTypeAggregate;
		}

		public async Task<PermissionsTypeModel> Handle(UpdatePermissionsTypeCommand request, CancellationToken cancellationToken)
		{
			await validator.ValidateAndThrowAsync(request);

			using (context)
			{
				if (DidThePermissionsTypeChange(request))
				{
					permissionsTypeAggregate.UpdatePermissionsType(request.PermissionsType);
					try
					{
						context.PermissionsType.Update(permissionsTypeAggregate.PermissionsType);
						context.SaveChanges();
					}
					catch (Exception ex)
					{
						throw new ArgumentException($"An error ocurred while updating the entity {permissionsTypeAggregate.PermissionsType.Id}.", ex);
					}
				}
			}

			return request.PermissionsType;
		}

		private bool DidThePermissionsTypeChange(UpdatePermissionsTypeCommand request)
		{
			var currentPermissionsType = context.PermissionsType
				.AsNoTracking()
				.SingleOrDefault(s => s.Id == request.PermissionsType.Id);

			if (currentPermissionsType != null && (currentPermissionsType.Descripcion != request.PermissionsType.Descripcion))
			{
				return true;
			}
			return false;
		}

		public class UpdatePermissionsTypeCommandValidator : AbstractValidator<UpdatePermissionsTypeCommand>
		{
			public UpdatePermissionsTypeCommandValidator()
			{
				RuleFor(a => a.PermissionsType.Id).GreaterThan(0);
				RuleFor(a => a.PermissionsType.Descripcion).NotEmpty().NotNull();
			}
		}
	}
}

