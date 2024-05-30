using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarRecordCases.Commands
{
    public class CreateCarRecordCommand: IRequest<ResponceModel>
    {
        public Guid UserCarId { get; set; }
        public int Probeg { get; set; }
        public string RecordTask { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }
    }
}
