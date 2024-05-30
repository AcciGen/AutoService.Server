using AutoService.Application.Abstractions;
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
    public class UpdateNewsCommentCommandHandler : IRequestHandler<UpdateNewsCommentCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateNewsCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateNewsCommentCommand request, CancellationToken cancellationToken)
        {
                var res2 = await _context.newsComments.FirstOrDefaultAsync(x => x.Id == request.CommentId);

                if (res2 != null)
                {
                    res2.Comment = request.newComment;

                    _context.newsComments.Update(res2);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponceModel
                    {
                        Message = "Your comment updated!",
                        IsSuccess = true,
                        StatusCode = 200
                    };
                }
                return new ResponceModel
                {
                    Message = "Something went wrong!",
                    StatusCode = 401
                };
            }
    }
}
