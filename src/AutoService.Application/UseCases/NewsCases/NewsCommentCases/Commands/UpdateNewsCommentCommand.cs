using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Commands
{
    public class UpdateNewsCommentCommand : IRequest<ResponceModel>
    {
        public Guid CommentId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string newComment { get; set; }
    }
}
