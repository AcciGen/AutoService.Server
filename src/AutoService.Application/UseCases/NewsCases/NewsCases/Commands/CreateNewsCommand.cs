using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Commands
{
    public class CreateNewsCommand : IRequest<ResponceModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? MainPhotoPath { get; set; }
    }
}
