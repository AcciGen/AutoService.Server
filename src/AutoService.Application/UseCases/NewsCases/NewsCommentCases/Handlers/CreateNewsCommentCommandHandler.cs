using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands;
using AutoService.Application.UseCases.NewsCases.NewsCommentCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.NewsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Handlers
{
    public class CreateNewsCommentCommandHandler : IRequestHandler<CreateNewsCommentCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateNewsCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateNewsCommentCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.news.FirstOrDefaultAsync(x => x.Id == request.NewsId);

            if (res != null)
            {
                var comment = new NewsComment
                {
                    NewsId = res.Id,
                    userFirstName = request.userFirstName,
                    userLastName = request.userLastName,
                    Comment = request.Comment
                };

                await _context.newsComments.AddAsync(comment);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Comment added",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "Something went wrong",
                StatusCode = 401
            };
        }
    }
}
