using BackendPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public ServerResponse<UserDTO> Post([FromBody] User user)
        {
            UserRepository repo = new UserRepository();
            var userDTO = repo.LogIn(user.UserName, user.Password);

            var data = new List<UserDTO>();
            data.Add(userDTO);

            return new ServerResponse<UserDTO>()
            {
                Result = userDTO != null,
                Data = data
            };
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
