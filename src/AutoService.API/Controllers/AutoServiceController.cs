using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Queries;
using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.ViewModels.AutoServiceViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutoServiceController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AutoServiceController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateAutoService(CreateAutoServiceCommand news)
        {
            var res = await _mediatr.Send(news);

            return res;
        }

        [HttpGet]
        public async Task<List<AutoServiceModel>> GetAllAutoService([FromQuery] GetAllAutoServices request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteAutoService(DeleteAutoServiceCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
