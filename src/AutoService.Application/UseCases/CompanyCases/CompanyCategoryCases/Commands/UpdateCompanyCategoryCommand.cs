using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Commands
{
    public class UpdateCompanyCategoryCommand : IRequest<ResponceModel>
    {
        public Guid categoryId { get; set; }
        public string newName { get; set; }
    }
}
