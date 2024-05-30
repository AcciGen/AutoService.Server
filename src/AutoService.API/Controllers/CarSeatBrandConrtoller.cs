using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Queries;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarSeatBrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarSeatBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateCarSeatBrand(CreateCarSeatBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<IEnumerable<CarSeatBrand>> GetAllCarSeatBrand([FromQuery] GetAllCarSeatBrandQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateCarSeatBrand(UpdateCarSeatBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteCarSeatBrand(DeleteCarSeatBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
