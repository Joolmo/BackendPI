using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendPI.Models
{
    public class ChildClassroom
    {
        [Key]
        public int ChildId { get; set; }
        public Child Child { get; set; }

        [Key]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}