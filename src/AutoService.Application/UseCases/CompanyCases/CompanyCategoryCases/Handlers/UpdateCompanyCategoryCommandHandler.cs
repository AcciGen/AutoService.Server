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
    public class UpdateCompanyCategoryCommandHandler : IRequestHandler<UpdateCompanyCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCompanyCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCompanyCategoryCommand request, CancellationToken cancellationToken)
        {
            var ctg = await _context.CompanyCategories.FirstOrDefaultAsync(x => x.Id == request.categoryId);

            if (ctg != null)
            {
                ctg.CategoryName = request.newName;
                _context.CompanyCategories.Update(ctg);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Category updated",
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
