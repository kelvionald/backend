using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Data.Models
{
    public class Review : AbstractModel
    {
        public int BikeId { get; set; }
        public string ReviewerName { get; set; }
        public string Content { get; set; }
    }
}
