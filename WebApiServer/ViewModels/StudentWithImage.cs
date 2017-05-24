using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiServer.Models;

namespace WebApiServer.ViewModels
{
    public class StudentWithImage
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string ImagePath { get; set; }
    }
}