using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
namespace BackendPI.Models
{
    public class ReportRepository
    {
        internal List<Report> RetrieveByChild(int id)
        {
            List<Report> reports = new List<Report>();
            using (BackendContext context = new BackendContext())
            {
                reports = context.Children
                    .Where(s => s.Id == id)
                    .Include(s => s.Reports)
                    .Select(s => s.Reports)
                    .FirstOrDefault();
            }
            return reports;
        }

        internal List<Report> RetriveByTeacher(int id)
        {
            List<Report> reports;

            try
            {
                using (BackendContext context = new BackendContext())
                {
                    reports = context.Teachers
                        .Where(t => t.Id == id)
                        .Include(t => t.TeachersClasrooms)
                        .ThenInclude(tc => tc.Classroom.ChildrenClassrooms)
                        .ThenInclude(cc => cc.Child.Reports)
                        .Select(t => t.TeachersClasrooms.Select(tc => tc.Classroom.ChildrenClassrooms.Select(cc => cc.Child.Reports)))
                        .SingleOrDefault()
                        .Aggregate((acc, ele) => acc.Concat(ele))
                        .Aggregate((acc, ele) => { acc.AddRange(ele); return acc; });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return reports;
        }

        internal void Save(Report r)
        {
            BackendContext context = new BackendContext();

            context.Reports.Add(r);
            context.SaveChanges();
        }
    }
}