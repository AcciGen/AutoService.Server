using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Handlers
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteCarCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Cars.FirstOrDefaultAsync(x=>x.Id == request.Id);
            if(res != null) 
            {
                _context.Cars.Remove(res);

                return new ResponceModel
                {
                    Message = "Deleted Car",
                    StatusCode = 200,
                    IsSuccess = true,
                };
            }
            return new ResponceModel
            {
                Message = "We couldnt delete",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
