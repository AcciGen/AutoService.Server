using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Queries;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers.QueryHandlers
{
    public class GetByIdCarSeatQueryHandler : IRequestHandler<GetByIdCarSeatQuery,CarSeat>
    {
        private readonly IAppDbContext _appDbContext;
        public GetByIdCarSeatQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
         
        public async Task<CarSeat> Handle(GetByIdCarSeatQuery request,CancellationToken cancellationToken) 
        {
            var carseat = await _appDbContext.CarSeats.FirstOrDefaultAsync(x=>x.Id ==request.id);
            return carseat;
        }
    }
}
