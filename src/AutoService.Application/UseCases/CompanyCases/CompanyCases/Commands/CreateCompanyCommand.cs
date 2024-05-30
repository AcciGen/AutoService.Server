using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands
{
    public class CreateCompanyCommand : IRequest<ResponceModel>
    {
        public Guid CompanyCategoryId { get; set; }
        public IFormFile FormFile { get; set; }
        public string CompanyName { get; set; }

        [MaxLength(2000)]
        public string CompanyHistory { get; set; }
        public List<Guid> ServicesId { get; set; }

    }
}
