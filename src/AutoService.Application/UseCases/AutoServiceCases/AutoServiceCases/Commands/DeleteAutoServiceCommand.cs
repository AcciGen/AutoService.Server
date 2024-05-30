using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands
{
    public class DeleteAutoServiceCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
    }
}
