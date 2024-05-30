using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Queries;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Handlers.QueryHandlers
{
    public class GetAllByCategoryCompanyQueryHandler : IRequestHandler<GetAllByCategoryCompanyQuery, List<Company>>
    {
        private readonly IAppDbContext _context;

        public GetAllByCategoryCompanyQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> Handle(GetAllByCategoryCompanyQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var companies = await _context.Companies
                .Skip(request.PageIndex - 1)
                .Take(request.Size)
                .ToListAsync(cancellationToken);


            return companies;

        }
    }
}
