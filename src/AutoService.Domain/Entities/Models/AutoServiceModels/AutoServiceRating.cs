using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.AutoServiceModels
{
    public class AutoServiceRating
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public Guid AutoServiceId { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceId { get; set; }
        public string Comment { get; set; }
        public virtual User User { get; set; }
        public virtual UserCar Car { get; set; }
        public virtual AutoServiceModel AutoService { get; set; }
        public virtual Service Service { get; set; }

    }
}
