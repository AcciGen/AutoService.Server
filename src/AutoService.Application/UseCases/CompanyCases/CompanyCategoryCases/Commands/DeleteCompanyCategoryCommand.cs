using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Commands
{
    public class DeleteCompanyCategoryCommand : IRequest<ResponceModel>
    {
        public Guid ctgId { get; set; }
    }
}
