using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendPI.Models
{
    public class ChildClassroom
    {
        public int Id { get; set; }

        public int ChildId { get; set; }
        public Child Child { get; set; }

        public int ClasroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}