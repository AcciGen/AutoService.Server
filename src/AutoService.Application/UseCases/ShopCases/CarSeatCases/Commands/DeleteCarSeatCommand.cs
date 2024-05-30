using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands
{
    public class DeleteCarSeatCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
    }
}
