using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Queries;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateServiceCategory(CreateServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<List<ServiceCategory>> GetAllServiceCategory([FromQuery] GetAllServiceCategoryQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateServiceCategory(UpdateServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteServiceCategory(DeleteServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
