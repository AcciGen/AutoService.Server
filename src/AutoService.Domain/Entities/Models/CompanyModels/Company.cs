using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.CompanyModels
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CompanyCategoriesId { get; set; }
        public string Photo {  get; set; }
        public string CompanyName { get; set; }

        [MaxLength(2000)]
        public string CompanyHistory {  get; set; }
        public List<Guid> ServicesId { get; set; }


        public virtual CompanyCategory CompanyCategories { get; set; }
        public virtual List<Service> Services { get; set; }


    }
}
