using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using permissions_n5_challenge.Domain.Contexts;
using permissions_n5_challenge.Domain.Models.PermissionsTypes;

namespace permissions_n5_challenge.Application.Queries.PermissionsType
{
    public class GetPermissionsTypeByIdQuery : IRequest<PermissionsTypeModel>
    {
        public GetPermissionsTypeByIdQuery(int Id)
        {
            Id = Id;
        }

        public int Id { get; set; }
    }

    public class GetPermissionsTypeByIdQueryHandler : IRequestHandler<GetPermissionsTypeByIdQuery, PermissionsTypeModel>
    {
        private readonly IPermissionsDbContext context;
        private readonly IValidator<GetPermissionsTypeByIdQuery> validator;

        public GetPermissionsTypeByIdQueryHandler(IPermissionsDbContext context, IValidator<GetPermissionsTypeByIdQuery> validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public async Task<PermissionsTypeModel> Handle(GetPermissionsTypeByIdQuery request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            using (context)
            {
                return await context.PermissionsType
                        .AsNoTracking()
                        .Where(c => c.Id == request.Id)
                        .Select(c => new PermissionsTypeModel(c)).FirstOrDefaultAsync();
            }
        }
    }

    public class GetPermissionsTypeByIdQueryValidator : AbstractValidator<GetPermissionsTypeByIdQuery>
    {
        public GetPermissionsTypeByIdQueryValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
