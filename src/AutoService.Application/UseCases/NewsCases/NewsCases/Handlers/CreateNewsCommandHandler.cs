using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.NewsModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Handlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateNewsCommandHandler(IAppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponceModel> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {

            string fileName = "";
            string filePath = "";

            if (request.MainPhotoPath is not null)
            {
                var file = request.MainPhotoPath;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "NewsPhoto", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }
                catch (Exception ex)
                {
                    return new ResponceModel
                    {
                        Message = $"{ex}",
                        StatusCode = 409
                    };
                }
            }


            var news = new News()
            {
                Name = request.Name,
                Description = request.Description,
                MainPhotoPath = "/NewsPhoto/" + fileName,
            };

            await _context.news.AddAsync(news);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "News created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
