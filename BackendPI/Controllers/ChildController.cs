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
        public ServerResponse<ChildDTO> GetAllChildren()
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
        public ServerResponse<ChildDTO> GetChildById(int id)
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

        public ServerResponse<Child> GetChildByClass(int idClass)
        {
            UserRepository repo = new UserRepository();
            var children = repo.getChildrenByClass(idClass);

            return new ServerResponse<Child>()
            {
                Data = children,
                Result = children != null
            };
        }

        // POST: api/Child
        public IHttpActionResult Post([FromBody]ChildDTO child)
        {
            if (child.Id != null) return BadRequest();
            if (child.Name == null) return BadRequest();
            if (child.Password == null) return BadRequest();
            if (child.Surname == null) return BadRequest();
            if (child.UserName == null) return BadRequest();

            var repo = new UserRepository();

            try {
                repo.SaveChild(child);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }

            return Ok();
        }

        // PUT: api/Child/5
        public IHttpActionResult Put([FromBody]ChildDTO child)
        {
            var repo = new UserRepository();
            if (repo.modifyChild(child)) return Ok();
            else return BadRequest();
        }

        // DELETE: api/Child/5
        [HttpDelete]
        public IHttpActionResult Delete(int childid)
        {
            try
            {
                var repository = new UserRepository();
                repository.deleteChild(childid);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
