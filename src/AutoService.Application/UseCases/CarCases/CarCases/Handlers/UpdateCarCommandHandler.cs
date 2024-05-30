using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCarCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res != null)
            {
                res.Brand = request.Brand;
                res.CarModel = request.CarModel;
                res.ProdYear = request.ProdYear;
                res.VINcode = request.VINcode;

                _context.Cars.Update(res);
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
                Message = "Error while updating!",
                StatusCode = 401
            };
        }
    }
}
