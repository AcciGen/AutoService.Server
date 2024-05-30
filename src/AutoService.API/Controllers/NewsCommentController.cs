using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Application.UseCases.NewsCases.NewsCommentCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCommentCases.Queries;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.NewsModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsCommentController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public NewsCommentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateNewsComment(CreateNewsCommentCommand news)
        {
            var res = await _mediatr.Send(news);

            return res;
        }

        [HttpGet]
        public async Task<List<NewsComment>> GetAllNewsComment([FromQuery] GetAllNewsCommentQuery request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateNewsComment(UpdateNewsCommentCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteNewsComment(DeleteNewsCommentCommand request)
        {
            var result = await _mediatr.Send(request);
            return result;
        }
    }
}
