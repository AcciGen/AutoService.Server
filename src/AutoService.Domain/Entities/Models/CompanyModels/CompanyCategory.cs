using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.CompanyModels
{
    public class CompanyCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CategoryName { get; set; }
        public Guid CompanyId { get; set; }
        public virtual List<Company> Company { get; set; }
    }
}
