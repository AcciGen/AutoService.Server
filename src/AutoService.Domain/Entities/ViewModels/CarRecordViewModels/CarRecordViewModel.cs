using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.ViewModels.CarRecordViewModels
{
    public class CarRecordViewModel
    {
        public Guid CarRecordId { get; set; }
        public Guid UserCarId { get; set; }
        public DateTimeOffset createdDate { get; set; } = DateTimeOffset.Now;
        public int Probeg { get; set; }
        public string RecordTask { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }
    }
}
