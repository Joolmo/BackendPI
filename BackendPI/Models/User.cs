using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Child> Children { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
