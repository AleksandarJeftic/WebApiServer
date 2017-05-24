using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiServer.Models;
using WebApiServer.DataAccessLayer;
using WebApiServer.ViewModels;


namespace WebApiServer.Controllers
{
    public class StudentController : ApiController
    {
        StudentDataContext Db = new StudentDataContext();

        // GET: Api/Student/GetAllStudents
        [HttpGet]
        public IList<StudentWithImage> GetAllStudents()
        {
            List<StudentWithImage> stwi = new List<StudentWithImage>();
            var students = Db.Students.ToList();
            foreach(var s in students)
            {
                var studentsWithImage = new StudentWithImage()
                {
                    StudentID=s.StudentID,
                    StudentName = s.StudentName,
                    StudentLastName = s.StudentLastName,
                    ImagePath = s.Image.ImagePath
                };
                stwi.Add(studentsWithImage);
            }
            return stwi; 
        }


        //GET: Api/Student/GetDetails/id
        [HttpGet]
        public StudentWithImage GetDetails(int id)
        {

            var students = Db.Students.ToList();

            var stwi = new StudentWithImage()
            {
                StudentID=id,
                StudentName = students.Find(s => s.StudentID == id).StudentName,
                StudentLastName = students.Find(s => s.StudentID == id).StudentLastName,
                ImagePath = students.Find(s => s.StudentID == id).Image.ImagePath
            };
            return stwi;
        }
        //POST: Api/Student/Create
        [HttpPost]
        public IHttpActionResult Create(StudentWithImage stwi)
        {
            var student = new Student { StudentName = stwi.StudentName, StudentLastName = stwi.StudentLastName };
            var image = new Image { ImagePath = stwi.ImagePath };

            student.Image = image;
            Db.Students.Add(student);
            Db.SaveChanges();
            
            return Ok();
        }

        //DELETE: Api/Student/Delete
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id<=0)
            {
                return BadRequest("Not valid student id");
            }
            var student = Db.Students.Where(s => s.StudentID == id).FirstOrDefault();
            var image = Db.Images.Where(i => i.Student.StudentID == id).FirstOrDefault();

            Db.Entry(image).State = System.Data.Entity.EntityState.Deleted;
            Db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            Db.SaveChanges();

            return Ok();
        }

        //UPDATE: Api/Student/Update
        [HttpPost]
        public IHttpActionResult Update(StudentWithImage stwi)
        {
            var existingStudent = Db.Students.Where(st => st.StudentID == stwi.StudentID).FirstOrDefault();
            if (existingStudent!=null)
            {
                existingStudent.StudentName = stwi.StudentName;
                existingStudent.StudentLastName = stwi.StudentLastName;
                existingStudent.Image.ImagePath = stwi.ImagePath;

                Db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

    }
}