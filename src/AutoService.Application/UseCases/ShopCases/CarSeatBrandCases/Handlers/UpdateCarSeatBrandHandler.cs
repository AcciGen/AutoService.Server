using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Handlers
{
    public class UpdateCarSeatBrandHandler : IRequestHandler<UpdateCarSeatBrandCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCarSeatBrandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCarSeatBrandCommand request, CancellationToken cancellationToken)
        {
            var carSeatBrand = await _context.CarSeatBrands.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (carSeatBrand != null)
            {
                carSeatBrand.Name = request.Name;
                _context.CarSeatBrands.Update(carSeatBrand);
                await _context.SaveChangesAsync(cancellationToken); // Await save changes
                return new ResponceModel
                {
                    Message = "Changes saved!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            return new ResponceModel
            {
                Message = "Car seat brand not found",
                StatusCode = 404,
                IsSuccess = false
            };
        }
    }
}
