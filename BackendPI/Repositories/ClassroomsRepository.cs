using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BackendPI.Models
{
    public class ClassroomsRepository
    {
        public List<ClassroomDTO> RetrieveByTeacher(int idTeacher)
        {
            var context = new BackendContext();
            List<ClassroomDTO> classrooms;

            try
            {
                classrooms = context.Teachers
                 .Where(t => t.Id == idTeacher)
                 .Include(t => t.TeachersClasrooms)
                 .ThenInclude(tc => tc.Classroom)
                 .Select(t => t.TeachersClasrooms.Select(tc => tc.Classroom))
                 .FirstOrDefault()
                 .Select(c => new ClassroomDTO()
                 {
                     Id = c.Id,
                     Name = c.Name
                 })
                 .ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return classrooms;
        }

        public List<ClassroomDTO> RetrieveClassrooms()
        {
            List<ClassroomDTO> classrooms;

            try
            {
                using (var context = new BackendContext())
                {
                    classrooms = context.Classrooms
                        .Select(c => new ClassroomDTO()
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return classrooms;
        }

        internal void SaveClassroom(Classroom classroom)
        {
            using(BackendContext context = new BackendContext())
            {
                context.Classrooms.Add(classroom);
                context.SaveChanges();
            }
        }

        internal bool AddClassroomToTeacher(int idteacher, int idclass)
        {
            TeacherClassroom teacherClassroom;

            try
            {
                using (BackendContext context = new BackendContext())
                {
                    teacherClassroom = new TeacherClassroom()
                    {
                        ClassroomId = idclass,
                        TeacherId = idteacher,
                    };

                    context.TeacherClassrooms.Add(teacherClassroom);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        internal void AddClassroomToChild(int idchild, int idclass)
        {
            BackendContext context = new BackendContext();

            ChildClassroom childClassroom = new ChildClassroom()
            {
                ClassroomId = idclass,
                ChildId = idchild
            };

            context.ChildClassrooms.Add(childClassroom);
            context.SaveChanges();
        }

        internal void Eliminar(ChildClassroom childClassroom)
        {
            using (BackendContext context = new BackendContext())
            {
                var child = context.ChildClassrooms
                    .Where(e => e.ChildId == childClassroom.ChildId && e.ClassroomId == childClassroom.ClassroomId)
                    .FirstOrDefault();

                context.ChildClassrooms.Remove(child);
                context.SaveChanges();
            }
        }
    }
}