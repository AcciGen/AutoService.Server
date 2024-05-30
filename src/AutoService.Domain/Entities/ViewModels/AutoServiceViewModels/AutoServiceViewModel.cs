using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.ViewModels.AutoServiceViewModels
{
    public class AutoServiceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string location { get; set; }
    }
}
