using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class ShowStudentModel
    {
        public Student Student { get; set; }
        public List<Mark> Marks { get; set; }
        public TeacherAccount TeacherAccount { get; set; }
        public bool IsTeacher { get; set; }
    }
}
