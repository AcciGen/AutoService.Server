using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Handlers
{
    public class DeleteServiceCategoryCommandHandler : IRequestHandler<DeleteServiceCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteServiceCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var serviceCategory = await _appDbContext.ServiceCategories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (serviceCategory == null)
            {
                return new ResponceModel
                {
                    IsSuccess = false,
                    StatusCode = 200,
                    Message = "Service category not found"
                };
            }

            _appDbContext.ServiceCategories.Remove(serviceCategory);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                IsSuccess = true,
                Message = "Service category deleted successfully"
            };
        }
    }
}
