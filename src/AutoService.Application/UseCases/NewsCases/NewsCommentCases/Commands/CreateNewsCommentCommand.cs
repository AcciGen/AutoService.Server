using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Commands
{
    public class CreateNewsCommentCommand : IRequest<ResponceModel>
    {
        public Guid NewsId { get; set; }

        public string userFirstName { get; set; }

        public string userLastName { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
