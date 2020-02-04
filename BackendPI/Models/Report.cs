using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPI.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Child Child { get; set; }
        public int IdChild { get; set; }
    }
}
