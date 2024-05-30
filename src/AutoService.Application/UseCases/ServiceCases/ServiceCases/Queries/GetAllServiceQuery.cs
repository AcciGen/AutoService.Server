using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ServiceModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Queries
{
    public class GetAllServiceQuery: IRequest<List<Service>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; } = 10;
    }
}
