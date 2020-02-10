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
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Authenticate([FromBody] User user)
        {
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            UserRepository repo = new UserRepository();
            var userDTO = repo.LogIn(user.UserName, user.Password);

            if (userDTO != null)
            {
                userDTO.Token = TokenGenerator.GenerateTokenJwt(userDTO.UserName);
                var data = new List<UserDTO>();
                data.Add(userDTO);

                var result = new ServerResponse<UserDTO>()
                {
                    Result = userDTO != null,
                    Data = data
                };

                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
