using AutoService.Domain.Entities.Models.CompanyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.ServiceModels
{
    public class ServiceCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public virtual List<Service> Services { get; set; }

    }
}
