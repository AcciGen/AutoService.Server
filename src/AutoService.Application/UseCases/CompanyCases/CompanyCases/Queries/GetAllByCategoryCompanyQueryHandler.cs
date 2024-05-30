using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Queries
{
    public class GetAllByCategoryCompanyQuery : IRequest<List<Company>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; } = 10;
        public string CategoryName { get; set; }
    }
}
