using AutoService.Application.UseCases.CarCases.CarRecordCases.Commands;
using AutoService.Application.UseCases.CarCases.CarRecordCases.Queries;
using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.ViewModels.CarRecordViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarRecordController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CarRecordController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateCarRecord(CreateCarRecordCommand news)
        {
            var res = await _mediatr.Send(news);

            return res;
        }

        [HttpGet]
        public async Task<IEnumerable<CarRecord>> GetAllCarRecord([FromQuery] GetAllCarRecordQuery request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteCarRecord(DeleteCarRecordCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
