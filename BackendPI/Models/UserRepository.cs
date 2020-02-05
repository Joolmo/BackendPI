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

        internal User RetrieveTeacher(int id) {
            User teacher;

            using (var context = new BackendContext()) {
                teacher = context.Users
                    .Include(s => s.Teacher)
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            }

            return teacher;
        }

        internal User RetrieveChild(int id)
        {
            User child;

            using (var context = new BackendContext())
            {
                child = context.Users
                    .Include(s => s.Child)
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            }

            return child;
        }
    }
}