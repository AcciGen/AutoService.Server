using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands
{
    public class UpdateServiceCommand: IRequest<ResponceModel>
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
    }
}
