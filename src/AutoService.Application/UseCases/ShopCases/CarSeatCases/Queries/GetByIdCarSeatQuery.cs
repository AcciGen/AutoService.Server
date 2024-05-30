using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Queries
{
    public class GetByIdCarSeatQuery : IRequest<CarSeat>
    {
        public Guid id { get; set; }
    }
}
