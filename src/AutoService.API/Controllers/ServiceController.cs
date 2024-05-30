using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ServiceModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateService(CreateServiceCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<List<Service>> GetAllService([FromQuery] GetAllServiceQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateService(UpdateServiceCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteService(DeleteServiceCommand request) 
        {
            var result =await _mediator.Send(request);
            return result;
        }
    }
}
