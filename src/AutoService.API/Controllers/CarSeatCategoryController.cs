using AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Queries;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.Commands;
using AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.QueriesHandler;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarSeatCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarSeatCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateCarSeatCategory(CreateCarSeatCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<IEnumerable<CarSeatCategory>> GetAllCarSeatCategory([FromQuery] GetAllCarSeatCategoryQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
