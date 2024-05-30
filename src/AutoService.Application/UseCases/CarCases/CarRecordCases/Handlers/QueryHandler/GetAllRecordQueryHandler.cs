using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarRecordCases.Queries;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.ViewModels.CarRecordViewModels;
using AutoService.Domain.Entities.ViewModels.NewsCommentViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarRecordCases.Handlers.QueryHandler
{
    public class GetAllRecordQueryHandler : IRequestHandler<GetAllCarRecordQuery, IEnumerable<CarRecord>>
    {
        private readonly IAppDbContext _context;

        public GetAllRecordQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarRecord>> Handle(GetAllCarRecordQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CarRecords.ToListAsync(cancellationToken);

   

            return res.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList(); ;
        }

    }
}
