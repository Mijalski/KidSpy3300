using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class GradeAssignmentModel
    {
        public Assignment Assignment { get; set; }
        public List<Student> Students { get;set; }
        public List<MarkType> Marks { get; set; }
        public List<int> StudentIds { get; set; }
        
    }
}
