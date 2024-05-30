using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models
{
    public class ResponceModel
    {
        public string Message { get; set; } = String.Empty;

        public int StatusCode { get; set; }

        public bool IsSuccess { get; set; } = false;
    }
}
