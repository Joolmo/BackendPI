using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendPI.Models
{
    public class BackendContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<TeacherClassroom> TeacherClassrooms { get; set; }
        public DbSet<ChildClassroom> ChildClassrooms { get; set; }

        public BackendContext()
        {

        }

        public BackendContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=proyectointegrado.czg8xnl9zih7.us-east-2.rds.amazonaws.com;Database=BullyApp;Uid=root;Pwd='PI123456';");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>();
            builder.Entity<Child>();

            builder.Entity<ChildClassroom>()
                .HasKey(c => new { c.ClassroomId, c.ChildId });
            builder.Entity<TeacherClassroom>()
                .HasKey(c => new { c.ClassroomId, c.TeacherId });

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
