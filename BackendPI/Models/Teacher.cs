using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPI.Models
{
    public class Teacher
    {
        [ForeignKey(nameof(User))]
        public int Id { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public List<TeacherClassroom> TeachersClasrooms { get; set; }
    }

    public class TeacherDTO {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
 
}
