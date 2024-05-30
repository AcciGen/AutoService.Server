using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.Models.UserModels;
using AutoService.Domain.Entities.ViewModels.CompanyCategoryViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Queries
{
    public class GetAllCompanyCategoryQuery : IRequest<List<CompanyCategory>>
    {
        public int PageIndex { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
