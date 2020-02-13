using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackendPI.Models;

namespace BackendPI.Controllers
{
    [Authorize]
    public class ReportController : ApiController
    {
        // GET: api/Report/5
        public ServerResponse<Report> GetByChild(int idChild)
        {
            ReportRepository repo = new ReportRepository();
            var reports = repo.RetrieveByChild(idChild);

            return new ServerResponse<Report>()
            {
                Result = reports != null,
                Data = reports
            };
        }

        public ServerResponse<Report> GetByTeacher(int idTeacher)
        {
            ReportRepository repo = new ReportRepository();
            var reports = repo.RetriveByTeacher(idTeacher);

            return new ServerResponse<Report>()
            {
                Result = reports != null,
                Data = reports
            };
        }

        // POST: api/Report
        public IHttpActionResult addReport([FromBody]Report report)
        {
            var repo = new ReportRepository();
            repo.Save(report);
            return Ok();
        }
    }
}
