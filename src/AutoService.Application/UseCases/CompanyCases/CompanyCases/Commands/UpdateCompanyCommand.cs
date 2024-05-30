using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands
{
    public class UpdateCompanyCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
        public Guid CompanyCategoryId { get; set; }
        public IFormFile? PhotoPath { get; set; }
        public string CompanyName { get; set; }

        [MaxLength(2000)]
        public string CompanyHistory { get; set; }

        public List<Guid> ServicesId { get; set; }

    }
}
