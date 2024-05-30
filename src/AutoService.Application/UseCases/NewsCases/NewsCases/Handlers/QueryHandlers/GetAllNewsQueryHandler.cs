using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Domain.Entities.Models.NewsModels;
using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Handlers.QueryHandlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<News>>
    {
        private readonly IAppDbContext _context;

        public GetAllNewsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var News = await _context.news.ToListAsync(cancellationToken);

            return News.Skip(request.PageIndex - 1)
                    .Take(request.Size).ToList();
        }
    }
}
