using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace BackendPI.Models
{
    public class UserRepository {
        internal UserDTO LogIn(string username, string password) {
            using (var context = new BackendContext())
            {
                var result = context.Users
                    .Include(s => s.Child).Include(s => s.Teacher)
                    .Where(s => s.UserName == username && s.Password == password)
                    .ToList();

                //return result.Count != 0; //si es distinto de 0 true, al contrario false.
                if (result.Count == 0) {
                    return null;
                }
                else {
                    return result[0].Teacher == null ?
                        new UserDTO()
                        {
                            IsTeacher = false,
                            UserName = result[0].UserName,
                            Password = result[0].Password,
                            Id = result[0].Id
                        }
                        : new UserDTO()
                        {
                            IsTeacher = true,
                            UserName = result[0].UserName,
                            Password = result[0].Password,
                            Id = result[0].Id
                        };
                }
            }
        }

        //funciones que devuelvan un teacher y un child según su id.

        internal TeacherDTO RetrieveTeacher(int id) {
            TeacherDTO teacher;

            using (var context = new BackendContext()) {
                teacher = context.Users
                    .Include(s => s.Teacher)
                    .Where(s => s.Id == id)
                    .Select(s => new TeacherDTO() {
                        Id = s.Id,
                        Name = s.Teacher.Name,
                        Surname = s.Teacher.Surname,
                        UserName = s.UserName,
                        Password = s.Password
                    })
                    .FirstOrDefault();
            }

            return teacher;
        }

        internal List<TeacherDTO> RetrieveAllTeachers() {
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            using (BackendContext context = new BackendContext()) {
                teachers = context.Users
                    .Include(s => s.Teacher)
                    .Where(s => s.Teacher != null)
                    .Select(s => new TeacherDTO()
                    {
                        Id = s.Id,
                        Name = s.Teacher.Name,
                        Surname = s.Teacher.Surname,
                        UserName = s.UserName,
                        Password = s.Password
                    }).ToList();
            }
            return teachers;
        }

        internal ChildDTO RetrieveChild(int id)
        {
            ChildDTO child;

            using (var context = new BackendContext())
            {
                child = context.Users
                    .Include(s => s.Child)
                    .Where(s => s.Id == id)
                    .Select(s => new ChildDTO() {
                        Id = s.Id,
                        Name = s.Child.Name,
                        Surname = s.Child.Surname,
                        UserName = s.UserName,
                        Password = s.Password
                    })
                    .FirstOrDefault();
            }

            return child;
        }

        internal List<ChildDTO> RetrieveAllChildren()
        {
            List<ChildDTO> children = new List<ChildDTO>();
            using (BackendContext context = new BackendContext())
            {
                children = context.Users
                    .Include(s => s.Child)
                    .Where(s => s.Child != null)
                    .Select(s => new ChildDTO()
                    {
                        Id = s.Id,
                        Name = s.Child.Name,
                        Surname = s.Child.Surname,
                        UserName = s.UserName,
                        Password = s.Password
                    }).ToList();
            }
            return children;
        }

        internal void SaveTeacher(TeacherDTO t)
        {
            BackendContext context = new BackendContext();

            User user = new User() {
                UserName = t.UserName,
                Password = t.Password,
            };

            context.Users.Add(user);
            context.SaveChanges();

            var id = context.Users.Where(e => e.UserName == t.UserName).First().Id;
            Teacher teacher = new Teacher()
            {
                Id = id,
                Surname = t.Surname,
                Name = t.Name,
            };

            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        internal void SaveChild(ChildDTO c)
        {
            using (BackendContext context = new BackendContext())
            {
                User user = new User()
                {
                    UserName = c.UserName,
                    Password = c.Password,
                };

                context.Users.Add(user);
                context.SaveChanges();

                var id = context.Users.Where(e => e.UserName == c.UserName).First().Id;
                Child child = new Child()
                {
                    Id = id,
                    Surname = c.Surname,
                    Name = c.Name,
                };

                context.Children.Add(child);
                context.SaveChanges();
            }
        }

        internal void modifyChild(Child child)
        {
            BackendContext context = new BackendContext();

            context.Children.Update(child);
            context.SaveChanges();
        }

        internal void modifyTeacher(Teacher teacher)
        {
            BackendContext context = new BackendContext();

            context.Teachers.Update(teacher);
            context.SaveChanges();
        }

        internal List<Child> getChildrenByClass(int id)
        {
            List<Child> children;

            try
            {
                using (var context = new BackendContext())
                {
                    children = context.Classrooms
                        .Where(t => t.Id == id)
                        .Include(t => t.ChildrenClassrooms)
                        .ThenInclude(tc => tc.Child)
                        .Select(t => t.ChildrenClassrooms.Select(cc => cc.Child))
                        .FirstOrDefault()
                        .ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return children;
        }
    }
}