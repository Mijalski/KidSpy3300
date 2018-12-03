using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class SchoolClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeacherAccount TeacherAccount { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
