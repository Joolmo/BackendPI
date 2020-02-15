using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendPI.Models
{
    public class ChildClassroom
    {
        public int ChildId { get; set; }
        public Child Child { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}