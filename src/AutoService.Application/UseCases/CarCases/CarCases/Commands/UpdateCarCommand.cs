using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Commands
{
    public class UpdateCarCommand: IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string CarModel { get; set; }
        public string ProdYear { get; set; }
        public string VINcode { get; set; }
    }
}
