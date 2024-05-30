using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Queries;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.ViewModels.CompanyCategoryViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Handlers.QueryHandlers
{
    public class GetAllCompanyCategoryQueryHandler : IRequestHandler<GetAllCompanyCategoryQuery, List<CompanyCategory>>
    {
        private readonly IAppDbContext _context;

        public GetAllCompanyCategoryQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyCategory>> Handle(GetAllCompanyCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _context.CompanyCategories
                            .ToListAsync();
        }
    }
}
