using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Handlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateServiceCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (service == null)
            {
                return new ResponceModel
                {
                    Message = "Service Not Found",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            service.Name = request.Name;
            _appDbContext.Services.Update(service); // Update service, not service category
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "Service updated successfully",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
