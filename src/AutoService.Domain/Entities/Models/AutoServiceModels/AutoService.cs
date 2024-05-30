using AutoService.Domain.Entities.Models.CompanyModels;
using AutoService.Domain.Entities.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.AutoServiceModels
{
    public class AutoServiceModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CompanyId { get; set; }
        public string Photo {  get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string WebSitePath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Guid> ServicesId { get; set; }

        public virtual List<Service> Services { get; set; }
        public virtual Company Company { get; set; }
    }
}
