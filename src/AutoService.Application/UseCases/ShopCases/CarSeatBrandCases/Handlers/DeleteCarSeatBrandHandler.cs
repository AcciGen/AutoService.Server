using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Handlers
{
    public class DeleteCarSeatBrandHandler : IRequestHandler<DeleteCarSeatBrandCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public DeleteCarSeatBrandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteCarSeatBrandCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeatBrands.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                _context.CarSeatBrands.Remove(res);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Your brand has removed!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "Not found",
                StatusCode = 401
            };
        }
    }
}
