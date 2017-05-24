using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiServer.Models;


namespace WebApiServer.DataAccessLayer
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext ()
            : base("StudentDataContext")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.Image)
                .WithRequired(img => img.Student);
        }
    }
}