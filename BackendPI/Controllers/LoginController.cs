using BackendPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;

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

        /*PRINCIPIO

        /// <summary>
        /// login controller class for authenticate users
        /// </summary>
        [AllowAnonymous]
        [RoutePrefix("api/login")]
        public class LoginController : ApiController
        {
            [HttpGet]
            [Route("echoping")]
            public IHttpActionResult EchoPing()
            {
                return Ok(true);
            }

            [HttpGet]
            [Route("echouser")]
            public IHttpActionResult EchoUser()
            {
                var identity = Thread.CurrentPrincipal.Identity;
                return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
            }

            [HttpPost]
            [Route("authenticate")]
            public IHttpActionResult Authenticate(LoginRequest login)
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                //TODO: Validate credentials Correctly, this code is only for demo !!
                bool isCredentialValid = (login.Password == "123456");
                if (isCredentialValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt(login.Username);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
        }

        // FIN*/

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
