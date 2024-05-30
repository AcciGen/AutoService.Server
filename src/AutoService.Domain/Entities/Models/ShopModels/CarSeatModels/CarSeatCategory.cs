using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.ShopModels.CarSeatModels
{
    public class CarSeatCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string startAge { get; set; }
        public string endAge { get; set; }
    }
}
