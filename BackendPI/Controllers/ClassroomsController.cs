using BackendPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendPI.Controllers
{
    public class ClassroomsController : ApiController
    {
        public ServerResponse<Classroom> GetByTeacher(int idTeacher)
        {
            var repo = new ClassroomsRepository();
            var result = repo.RetrieveByTeacher(idTeacher);

            return new ServerResponse<Classroom>()
            {
                Data = result,
                Result = result != null
            };
        }
    }
}
