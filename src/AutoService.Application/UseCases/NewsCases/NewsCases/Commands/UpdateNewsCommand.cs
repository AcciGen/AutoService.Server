using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Commands
{
    public class UpdateNewsCommand : IRequest<ResponceModel>
    {
        public Guid NewsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
    }
}
