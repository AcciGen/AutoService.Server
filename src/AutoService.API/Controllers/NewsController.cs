using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.NewsModels;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public NewsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateNews(CreateNewsCommand news)
        {
            var res = await _mediatr.Send(news);

            return res;
        }

        [HttpGet]
        public async Task<List<News>> GetAllNews([FromQuery] GetAllNewsQuery request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateNews(UpdateNewsCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteNews(DeleteNewsCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
