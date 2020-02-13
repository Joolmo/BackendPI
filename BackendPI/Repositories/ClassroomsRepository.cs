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
            List<Classroom> classrooms;

            try
            {
                classrooms = context.Teachers
                 .Where(t => t.Id == idTeacher)
                 .Include(t => t.TeachersClasrooms)
                 .ThenInclude(tc => tc.Classroom)
                 .Select(t => t.TeachersClasrooms.Select(tc => tc.Classroom))
                 .FirstOrDefault()
                 .ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return classrooms;
        }

        internal void SaveClassroom(Classroom c)
        {
            BackendContext context = new BackendContext();

            Classroom classroom = new Classroom()
            {
                Name = c.Name
            };

            context.Classrooms.Add(classroom);
            context.SaveChanges();
        }

        internal void AddClassroomToTeacher(int idteacher, int idclass)
        {
            BackendContext context = new BackendContext();

            TeacherClassroom teacherClassroom = new TeacherClassroom()
            {
                ClassroomId = idclass,
                TeacherId = idteacher,
            };

            context.TeacherClassrooms.Add(teacherClassroom);
            context.SaveChanges();
        }
    }
}