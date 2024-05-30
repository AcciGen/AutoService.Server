using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.ViewModels.CarSeatViewModels
{
    public class CarSeatViewModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Guarantee { get; set; }
        public double Mass { get; set; }
        public string Size { get; set; }
        public string ProdCountry { get; set; }
        public string CategoryStart { get; set; }
        public string CategoryEnd { get; set; }
        public string BrandName { get; set; }
    }
}
