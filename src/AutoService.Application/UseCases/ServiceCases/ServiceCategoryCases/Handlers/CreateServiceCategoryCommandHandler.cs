using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ServiceModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Handlers
{
    public class CreateServiceCategoryCommandHandler : IRequestHandler<CreateServiceCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateServiceCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = new ServiceCategory
            {
                Name = request.Name
            };
            await _appDbContext.ServiceCategories.AddAsync(result);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Service category created successfully"
            };
        }
    }
}
