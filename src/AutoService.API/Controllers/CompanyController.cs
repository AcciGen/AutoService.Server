using AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Handlers.QueryHandlers;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateCompany(CreateCompanyCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<List<Company>> GetAllCompany([FromQuery] GetAllByCategoryCompanyQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateCompanyCategory(UpdateCompanyCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteCompanyCategory(DeleteCompanyCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
