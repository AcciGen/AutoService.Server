using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Commands
{
    public class DeleteNewsCommentCommand : IRequest<ResponceModel>
    {
        public Guid CommentId { get; set; }
    }
}
