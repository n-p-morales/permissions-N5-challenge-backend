using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using permissions_n5_challenge.Domain.Contexts;
using permissions_n5_challenge.Domain.Models.Permission;

namespace permissions_n5_challenge.Application.Queries.Permissions
{
    public class GetPermissionsByIdQuery : IRequest<PermissionsModel>
    {
        public GetPermissionsByIdQuery(int Id)
        {
            Id = Id;
        }

        public int Id { get; set; }
    }

    public class GetPermissionsByIdQueryHandler: IRequestHandler<GetPermissionsByIdQuery, PermissionsModel>
    {
        private readonly IPermissionsDbContext context;
        private readonly IValidator<GetPermissionsByIdQuery> validator;

        public GetPermissionsByIdQueryHandler(IPermissionsDbContext context, IValidator<GetPermissionsByIdQuery> validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public async Task<PermissionsModel> Handle(GetPermissionsByIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            using (context)
            {
                return await context.Permissions
                        .AsNoTracking()
                        .Where(c => c.Id == request.Id)
                        .Select(c => new PermissionsModel(c)).FirstOrDefaultAsync();
            }
        }
    }

    public class GetPermissionsByIdQueryValidator : AbstractValidator<GetPermissionsByIdQuery>
    {
        public GetPermissionsByIdQueryValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
