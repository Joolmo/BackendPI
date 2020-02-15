using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackendPI.Models
{
    public class TeacherClassroom
    {
        [Key]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Key]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}