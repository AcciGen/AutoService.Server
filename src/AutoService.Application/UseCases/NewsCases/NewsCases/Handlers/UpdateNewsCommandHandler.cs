using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.NewsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Handlers
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateNewsCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news1 = await _appDbContext.news.FirstOrDefaultAsync(x => x.Id == request.NewsId);

            if (news1 != null)
            {

                news1.Name = request.Name;
                news1.Description = request.Description;
               
            

                _appDbContext.news.Update(news1);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "News created",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "First create a news",
                StatusCode = 401
            };
        }
    }
}
