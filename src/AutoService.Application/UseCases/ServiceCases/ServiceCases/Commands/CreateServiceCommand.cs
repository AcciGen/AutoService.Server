using AutoService.Domain.Entities.Models;
using MediatR;


namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands
{
    public class CreateServiceCommand : IRequest<ResponceModel>
    {
        public string Name { get; set; }
        public Guid ServicesId { get; set; }
    }
}
