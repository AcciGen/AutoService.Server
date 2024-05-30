using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;
        private readonly UserManager<User> _userManager;

        public CreateCarCommandHandler(IAppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ResponceModel> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                return new ResponceModel
                {
                    Message = "User not found",
                    StatusCode = 404
                };
            }
            var car = new UserCar()
            {
                UsersId = request.UserId,
                Brand = request.Brand,
                CarModel = request.CarModel,
                ProdYear = request.ProdYear,
                VINcode = request.VINcode
            };
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponceModel()
            {
                Message = "Car created",
                StatusCode = 200,
                IsSuccess = true
            };
        }


    }
}
