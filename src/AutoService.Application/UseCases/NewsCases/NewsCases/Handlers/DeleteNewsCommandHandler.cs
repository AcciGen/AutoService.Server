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
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteNewsCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.news.FirstOrDefaultAsync(x => x.Id == request.NewsId);

            if (news != null)
            {
                _context.news.Remove(news);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "News removed",
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
