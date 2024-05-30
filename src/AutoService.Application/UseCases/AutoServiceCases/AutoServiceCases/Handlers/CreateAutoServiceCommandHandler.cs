using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Handlers
{
    public class CreateAutoServiceCommandHandler : IRequestHandler<CreateAutoServiceCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;
   

        public CreateAutoServiceCommandHandler(IAppDbContext context)
        {
            _context = context;
          
        }

        public async Task<ResponceModel> Handle(CreateAutoServiceCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == request.CompanyId);
            if (company != null)
            {
                var servicesCheck = false;
                foreach (var s in request.ServicesId)
                {
                    if (company.ServicesId.Contains(s))
                    {
                        servicesCheck = true;
                    }
                    else servicesCheck = false;
                }
                if (servicesCheck)
                {
                    var autoservice = new AutoServiceModel
                    {
                        CompanyId = request.CompanyId,
                        Name = company.CompanyName,
                        Location = request.Location,
                        Photo = company.Photo,
                        WebSitePath = request.WebSitePath,
                        PhoneNumber = request.PhoneNumber,
                        Email = request.Email,
                        ServicesId = request.ServicesId,
                    };

                    await _context.AutoServices.AddAsync(autoservice);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponceModel
                    {
                        Message = "You succesfully registered your service!",
                        StatusCode = 200,
                        IsSuccess = true
                    };
                }
            }

            return new ResponceModel
            {
                Message = "This company doesnt exists!",
                StatusCode = 404
            };
        }
    }
}
