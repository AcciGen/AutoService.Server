using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Queries;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ServiceModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Handlers
{
    public class GetAllServiceQueryHandler: IRequestHandler<GetAllServiceQuery, List<Service>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllServiceQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Service>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken) 
        {
            var user = await _appDbContext.Services.ToListAsync();
            return user.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList();
        }
    }
}
