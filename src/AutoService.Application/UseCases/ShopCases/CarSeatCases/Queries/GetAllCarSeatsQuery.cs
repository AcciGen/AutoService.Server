using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Queries
{
    public class GetAllCarSeatsQuery: IRequest<IEnumerable<CarSeat>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; } = 10; 
    }
}
