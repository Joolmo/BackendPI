using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendPI.Models
{
    public class ClassroomsRepository
    {
        public List<Classroom> RetrieveByTeacher(int idTeacher)
        {
            var context = new BackendContext();
            var classesIds = context.Teachers
                .Where(t => t.Id == idTeacher)
                .Include(t => t.TeachersClasrooms)
                .Select(t => t.TeachersClasrooms)
                .FirstOrDefault()
                .Select(c => c.ClassroomId);

            var classes = context.Classrooms.Where(c => classesIds.Contains(c.Id)).ToList();
            return classes;
        }
    }
}