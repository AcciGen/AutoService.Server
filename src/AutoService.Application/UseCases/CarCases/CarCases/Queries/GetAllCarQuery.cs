using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.ViewModels.CarViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Queries
{
    public class GetAllCarQuery: IRequest<IEnumerable<UserCar>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; } = 10;
        public string UserId { get; set; }
    }
}
