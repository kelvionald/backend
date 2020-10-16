using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Data.Models
{
    public class Bike : AbstractModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int SpeedNumber { get; set; }
        public int ProducerId { get; set; }
        public int AgeTypeId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
