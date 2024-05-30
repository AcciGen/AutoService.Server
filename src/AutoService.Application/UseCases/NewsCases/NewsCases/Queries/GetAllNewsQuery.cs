using AutoService.Domain.Entities.Models.NewsModels;
using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Queries
{
    public class GetAllNewsQuery : IRequest<List<News>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; } = 10;
    }
}
