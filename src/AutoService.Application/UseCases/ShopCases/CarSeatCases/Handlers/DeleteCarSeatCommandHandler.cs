using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers
{
    public class DeleteCarSeatCommandHandler : IRequestHandler<DeleteCarSeatCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteCarSeatCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteCarSeatCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeats.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                _context.CarSeats.Remove(res);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Your CarSeat has removed!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "Not Found such kind of Seat",
                StatusCode = 401
            };
        }
    }
}
