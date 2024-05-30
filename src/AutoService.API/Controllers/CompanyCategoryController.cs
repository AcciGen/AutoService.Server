using AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Commands;
using AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Queries;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Queries;
using AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.Commands;
using AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.QueriesHandler;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateCompanyCategory(CreateCompanyCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<List<CompanyCategory>> GetAllCompanyCategory()
        {
            var res = await _mediator.Send(new GetAllCompanyCategoryQuery());
            return res;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateCompanyCategory(UpdateCompanyCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteCompanyCategory(DeleteCompanyCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
