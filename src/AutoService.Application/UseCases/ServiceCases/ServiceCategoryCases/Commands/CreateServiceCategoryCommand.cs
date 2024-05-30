using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands
{
    public class CreateServiceCategoryCommand: IRequest<ResponceModel>
    {
        public string Name { get; set; }
    }
}
