using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.ViewModels.CarViewModel
{
    public class CarViewModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTimeOffset ProdYear { get; set; }
        public string VINcode { get; set; }
        public string UserId { get; set; }
    }
}
