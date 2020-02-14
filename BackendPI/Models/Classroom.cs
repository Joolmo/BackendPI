using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPI.Models
{
    public class Classroom
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<ChildClassroom> ChildrenClassrooms { get; set; }
        public List<TeacherClassroom> TeachersClassrooms { get; set; }
    }

    public class ClassroomDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
 }
