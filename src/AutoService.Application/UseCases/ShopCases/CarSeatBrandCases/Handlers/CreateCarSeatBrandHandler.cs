using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Handlers
{
    public class CreateCarSeatBrandHandler : IRequestHandler<CreateCarSeatBrandCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCarSeatBrandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponceModel> Handle(CreateCarSeatBrandCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeatBrands.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (res == null)
            {
                var result = new CarSeatBrand
                {
                    Name = request.Name,
                };
                

                await _context.CarSeatBrands.AddAsync(result);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "You succesfully added a new brand!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "This brand already exists",
                StatusCode = 409
            };
        }
    }
}
