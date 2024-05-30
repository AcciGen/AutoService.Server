using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Handlers
{
    public class DeleteCompanyCategoryCommandHandler : IRequestHandler<DeleteCompanyCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteCompanyCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteCompanyCategoryCommand request, CancellationToken cancellationToken)
        {
            var ctg = await _context.CompanyCategories.FirstOrDefaultAsync(x => x.Id == request.ctgId);

            if (ctg != null)
            {
                _context.CompanyCategories.Remove(ctg);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Category removed",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "Category not found",
                StatusCode = 404
            };
        }
    }
}
