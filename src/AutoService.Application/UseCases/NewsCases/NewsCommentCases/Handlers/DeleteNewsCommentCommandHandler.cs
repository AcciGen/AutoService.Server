using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCommentCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Handlers
{
    public class DeleteNewsCommentCommandHandler : IRequestHandler<DeleteNewsCommentCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteNewsCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteNewsCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.newsComments.FirstOrDefaultAsync(x => x.Id == request.CommentId);

            if (comment != null)
            {
                _context.newsComments.Remove(comment);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Your comment have removed!",
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
