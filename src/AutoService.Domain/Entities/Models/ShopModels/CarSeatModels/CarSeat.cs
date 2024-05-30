using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.ShopModels.CarSeatModels
{
    public class CarSeat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public string Price { get; set; }
        public string Guarantee { get; set; }
        public double Mass {  get; set; }
        public string Size {  get; set; }
        public string ProdCountry {  get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public virtual CarSeatCategory Category { get; set; }
        public virtual CarSeatBrand Brand { get; set; }

    }
}
