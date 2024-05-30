using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.Handlers
{
    public class CreateCarSeatCategoryCommandHandler : IRequestHandler<CreateCarSeatCategoryCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCarSeatCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateCarSeatCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = new CarSeatCategory()
            {
                startAge = request.startAge,
                endAge = request.endAge,
            };
            await _context.CarSeatCategories.AddAsync(res);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel()
            {
                Message = "Succesfully Created",
                StatusCode = 201,
            };
        }

    }
}
