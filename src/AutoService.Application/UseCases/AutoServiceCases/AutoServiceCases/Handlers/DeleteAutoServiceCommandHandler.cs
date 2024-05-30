using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Handlers
{
    public class DeleteAutoServiceCommandHandler : IRequestHandler<DeleteAutoServiceCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteAutoServiceCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(DeleteAutoServiceCommand request, CancellationToken cancellationToken)
        {
            var res = await _appDbContext.AutoServices.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                _appDbContext.AutoServices.Remove(res);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponceModel()
                {
                    Message = "Your autoservice have removed!",
                    IsSuccess = true,
                    StatusCode = 200
                };

            }

            return new ResponceModel()
            {
                Message = "This autoservice haven't registered yet!",
                StatusCode = 200
            };
        }
    }
}
