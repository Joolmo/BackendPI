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

        public int IdChildren { get; set; }
    }
}
