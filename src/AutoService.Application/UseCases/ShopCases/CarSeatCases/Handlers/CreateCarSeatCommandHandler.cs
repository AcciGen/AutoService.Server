using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers
{
    public class CreateCarSeatCommandHandler : IRequestHandler<CreateCarSeatCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateCarSeatCommandHandler(IAppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponceModel> Handle(CreateCarSeatCommand request, CancellationToken cancellationToken)
        {
            string fileName = "";
            string filePath = "";

            if (request.Photo is not null)
            {
                var file = request.Photo;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CarSeatPhotos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                catch (Exception ex)
                {
                    return new ResponceModel()
                    {
                        Message = ex.Message,
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }
            }
            var res = new CarSeat();
            res.Name = request.Name;
            res.PhotoPath = "/CarSeatPhotos/" + fileName;
            res.Price = request.Price;
            res.CategoryId = request.CategoryId;
            res.BrandId = request.BrandId;
            res.Guarantee = request.Guarantee;
            res.Price = request.Price;
            res.Size = request.Size;
            res.Mass = request.Mass;
            res.ProdCountry = request.ProdCountry;

            await _appDbContext.CarSeats.AddAsync(res);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "You succesfully added CarSeat",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}


