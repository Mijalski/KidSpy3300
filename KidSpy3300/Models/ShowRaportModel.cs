using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class ShowRaportModel
    {
        public SchoolClass SchoolClass { get; set; }
        public List<Student> Students { get; set; }
        public List<Mark> MarksA { get; set; }
        public List<Mark> MarksB { get; set; }
        public List<Mark> MarksC { get; set; }
        public List<Mark> MarksD { get; set; }
        public List<Mark> MarksE { get; set; }
        public int AssignmentsTotal { get;set; }
        public List<Assignment> AssignmentsGraded { get;set; }
        public List<Assignment> AssignmentsNotGraded { get;set; }
        public int MarksTotal { get; set; }
    }
}
