using BackendPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendPI.Controllers
{
    public class TeacherController : ApiController
    {
        // GET: api/Teacher
        public ServerResponse<TeacherDTO> Get()
        {
            UserRepository repo = new UserRepository();
            var teachers = repo.RetrieveAllTeachers();

            return new ServerResponse<TeacherDTO>()
            {
                Result = teachers != null,
                Data = teachers
            };
        }

        // GET: api/Teacher/5
        public ServerResponse<TeacherDTO> Get(int id)
        {
            UserRepository repo = new UserRepository();
            var teacherDTO = repo.RetrieveTeacher(id);

            var data = new List<TeacherDTO>();
            data.Add(teacherDTO);

            return new ServerResponse<TeacherDTO>()
            {
                Result = teacherDTO != null,
                Data = data
            };
        }

        // POST: api/Teacher
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Teacher/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Teacher/5
        public void Delete(int id)
        {
        }
    }
}
