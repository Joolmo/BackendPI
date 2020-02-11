using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

            Teacher teacher = new Teacher()
            {
                Id = t.Id,
                Surname = t.Surname,
                Name = t.Name,
            };

            User user = new User() {
                Id = t.Id,
                UserName = t.UserName,
                Password = t.Password,
            };

            context.Users.Add(user);
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }
    }
}