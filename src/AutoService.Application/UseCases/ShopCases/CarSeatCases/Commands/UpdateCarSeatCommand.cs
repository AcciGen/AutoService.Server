using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands
{
    public class UpdateCarSeatCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public double Mass { get; set; }
        public string Size { get; set; }
        public string ProdCountry { get; set; }
        public string Guarantee { get; set; }
    }
}
