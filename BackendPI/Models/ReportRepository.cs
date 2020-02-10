using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
namespace BackendPI.Models
{
    public class ReportRepository
    {
        internal List<Report> RetrieveReports(int id)
        {
            List<Report> reports = new List<Report>();
            using (BackendContext context = new BackendContext())
            {
                reports = context.Users
                    .Include(s => s.Child)
                    .Include(s => s.Child.Reports)
                    .Where(s => s.Child.Id == id)
                    .Select(s => s.Child.Reports)
                    .FirstOrDefault();
            }
            return reports;
        }
    }
}