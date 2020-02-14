using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPI.Models
{
    [Table("Children")]
    public class Child 
    {
        [ForeignKey(nameof(User))]
        public int? Id { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public List<ChildClassroom> ChildrenClassrooms { get; set; }
        public List<Report> Reports { get; set; }
    }

    public class ChildDTO
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
