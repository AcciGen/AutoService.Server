using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Queries;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Handlers.QueryHandlers
{
    public class GetAllCarSeatBrandQueryHandler : IRequestHandler<GetAllCarSeatBrandQuery, IEnumerable<CarSeatBrand>>
    {
        private readonly IAppDbContext _context;

        public GetAllCarSeatBrandQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarSeatBrand>> Handle(GetAllCarSeatBrandQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeatBrands.ToListAsync(cancellationToken);
            
            return res.Skip(request.PageIndex - 1)
                    .Take(request.Size).ToList(); ;
        }
    }
}

