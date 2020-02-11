using BackendPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendPI.Controllers
{
    [Authorize]
    public class ChildController : ApiController
    {
        // GET: api/Child
        public ServerResponse<ChildDTO> Get()
        {
            UserRepository repo = new UserRepository();
            var children = repo.RetrieveAllChildren();

            return new ServerResponse<ChildDTO>()
            {
                Result = children != null,
                Data = children
            };
        }

        // GET: api/Child/5
        public ServerResponse<ChildDTO> Get(int id)
        {
            UserRepository repo = new UserRepository();
            var childDTO = repo.RetrieveChild(id);

            var data = new List<ChildDTO>();
            data.Add(childDTO);

            return new ServerResponse<ChildDTO>()
            {
                Result = childDTO != null,
                Data = data
            };
        }

        // POST: api/Child
        public void Post([FromBody]ChildDTO child)
        {
            var repo = new UserRepository();
            repo.SaveChild(child);
        }

        // PUT: api/Child/5
        public void Put([FromBody]Child child)
        {
            var repo = new UserRepository();
            repo.modifyChild(child);
        }

        // DELETE: api/Child/5
        public void Delete(int id)
        {
        }
    }
}
