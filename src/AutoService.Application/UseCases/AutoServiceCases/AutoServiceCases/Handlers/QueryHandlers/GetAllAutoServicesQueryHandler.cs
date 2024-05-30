using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Queries;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.ViewModels.AutoServiceViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Handlers.QueryHandlers
{
    public class GetAllAutoServicesQueryHandler : IRequestHandler<GetAllAutoServices, List<AutoServiceModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllAutoServicesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AutoServiceModel>> Handle(GetAllAutoServices request, CancellationToken cancellationToken)
        {
            var autoServices = await _context.AutoServices
                                             .ToListAsync(cancellationToken);

            

            return autoServices.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList(); ;
        }
    }
}
