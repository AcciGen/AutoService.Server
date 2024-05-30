using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarRecordCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.ViewModels.CarRecordViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarRecordCases.Handlers
{
    public class CreateCarRecordCommandHandler : IRequestHandler<CreateCarRecordCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCarRecordCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateCarRecordCommand request, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == request.UserCarId);

            if (car == null)
            {
                return new ResponceModel
                {
                    Message = "car not found",
                    StatusCode = 404
                };
            }
            var result = new CarRecord()
            {
                UserCaresId = request.UserCarId,
                Probeg = request.Probeg,
                RecordTask = request.RecordTask,
                Comment = request.Comment,
                Price = request.Price,
            };

            await _context.CarRecords.AddAsync(result);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "CarRecord created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
