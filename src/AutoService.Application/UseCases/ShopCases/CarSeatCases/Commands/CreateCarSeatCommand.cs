using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands
{
    public class CreateCarSeatCommand: IRequest<ResponceModel>
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public IFormFile? Photo{ get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public double Mass {  get; set; }
        public string Size {  get; set; }
        public string ProdCountry {  get; set; }
        public string Guarantee {  get; set; }
    }
}
