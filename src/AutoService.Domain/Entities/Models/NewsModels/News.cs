using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Domain.Entities.Models.NewsModels
{
    public class News
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string MainPhotoPath { get; set; }
        public string Description { get; set; }
    }
}
