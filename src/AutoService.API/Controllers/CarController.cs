using AutoService.Application.UseCases.CarCases.CarCases.Commands;
using AutoService.Application.UseCases.CarCases.CarCases.Queries;
using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CarController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateCar(CreateCarCommand news)
        {
            var res = await _mediatr.Send(news);

            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<UserCar>> GetAllCars([FromQuery] GetAllCarQuery request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateCar(UpdateCarCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteCar(DeleteCarCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
