using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands
{
    public class CreateCarSeatBrandCommand:IRequest<ResponceModel>
    {
        public string Name {  get; set; }
      
    }
}
