using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers
{
    public class UpdateCarSeatCommandHandler : IRequestHandler<UpdateCarSeatCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCarSeatCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCarSeatCommand request, CancellationToken cancellationToken)
        {
            var carSeat = await _context.CarSeats.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (carSeat != null)
            {
                carSeat.Name = request.Name;
                carSeat.Price = request.Price;
                carSeat.CategoryId = request.CategoryId;
                carSeat.BrandId = request.BrandId;
                carSeat.Mass = request.Mass;
                carSeat.Size = request.Size;
                carSeat.ProdCountry = request.ProdCountry;
                carSeat.Guarantee = request.Guarantee;

                _context.CarSeats.Update(carSeat); // Corrected entity update
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "Changes saved!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            return new ResponceModel
            {
                Message = "Car seat not found",
                StatusCode = 404,
                IsSuccess = false
            };
        }
    }
}
