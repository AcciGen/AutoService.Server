using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCommentCases.Queries;
using AutoService.Domain.Entities.Models.NewsModels;
using AutoService.Domain.Entities.ViewModels.NewsCommentViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Handlers.QueryHandlers
{
    public class GetAllNewsCommentQueryHandler : IRequestHandler<GetAllNewsCommentQuery, List<NewsComment>>
    {
        private readonly IAppDbContext _context;

        public GetAllNewsCommentQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NewsComment>> Handle(GetAllNewsCommentQuery request, CancellationToken cancellationToken)
        {

            return await _context.newsComments.Skip(request.PageIndex - 1)
                    .Take(request.Size).Where(x=>x.NewsId == request.NewsId)
                            .ToListAsync(cancellationToken);
        }
    }
}
