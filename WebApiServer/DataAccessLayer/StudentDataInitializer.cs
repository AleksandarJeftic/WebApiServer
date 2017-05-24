using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiServer.Models;

namespace WebApiServer.DataAccessLayer
{
    public class StudentDataInitializer : DropCreateDatabaseIfModelChanges<StudentDataContext>
    {
        protected override void Seed(StudentDataContext context)
        {
            var student=new Student() { StudentName="Aleksandar",StudentLastName="Jeftic"};
            var image = new Image() { ImagePath="~/Images/Slika1.jpg"};

            student.Image = image;
            context.Students.Add(student);
            
            context.SaveChanges();
            base.Seed(context);
        }
    }
}