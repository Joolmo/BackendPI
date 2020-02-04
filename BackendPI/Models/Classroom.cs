using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPI.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Child> Children { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
