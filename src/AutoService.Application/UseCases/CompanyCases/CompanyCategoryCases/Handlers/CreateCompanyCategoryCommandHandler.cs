using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CompanyModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCategoryCases.Handlers
{
    public class CreateCompanyCategoryCommandHandler : IRequestHandler<CreateCompanyCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCompanyCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateCompanyCategoryCommand request, CancellationToken cancellationToken)
        {
            var companyCategory = await _context.CompanyCategories.FirstOrDefaultAsync(x => x.CategoryName == request.Name);

            if (companyCategory == null)
            {
                var ctgComp = new CompanyCategory
                {
                    CategoryName = request.Name,
                };

                await _context.CompanyCategories.AddAsync(ctgComp);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Category company created",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "This category already exists",
                StatusCode = 409
            };
        }
    }
}
