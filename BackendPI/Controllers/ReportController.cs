using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackendPI.Models;

namespace BackendPI.Controllers
{
    public class ReportController : ApiController
    {
        // GET: api/Report
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Report/5
        public ServerResponse<Report> Get(int id)
        {
            ReportRepository repo = new ReportRepository();
            var report = repo.RetrieveReports(id);

            return new ServerResponse<Report>()
            {
                Result = report != null,
                Data = report
            };
        }

        // POST: api/Report
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Report/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Report/5
        public void Delete(int id)
        {
        }
    }
}
