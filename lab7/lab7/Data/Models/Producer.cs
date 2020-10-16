using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Data.Models
{
    public class Producer : AbstractModel
    {
        public string Name { get; set; }
        public int FoundationYear { get; set; }
        public string Description { get; set; }
    }
}
