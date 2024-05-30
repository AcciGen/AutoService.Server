using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarRecordCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarRecordCases.Handlers
{
    public class DeleteCarRecordCommandHandler : IRequestHandler<DeleteCarRecordCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteCarRecordCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteCarRecordCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.CarRecords.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res != null)
            {
                _context.CarRecords.Remove(res);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Your Record have removed!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "Something went wrong",
                StatusCode = 401
            };
        }
    }
}

