using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Queries;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers.QueryHandlers
{
    public class GetAllCarSeatQueryHandler : IRequestHandler<GetAllCarSeatsQuery, IEnumerable<CarSeat>>
    {
        private readonly IAppDbContext _context;

        public GetAllCarSeatQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarSeat>> Handle(GetAllCarSeatsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeats.ToListAsync(cancellationToken);
            
            return res.Skip(request.PageIndex - 1)
                    .Take(request.Size).ToList(); ;
        }
    }
}
