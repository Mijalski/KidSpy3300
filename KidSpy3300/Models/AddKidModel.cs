using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class AddKidModel
    {
        [Required]
        [MinLength(3)]
        public string StudentName { get; set; }

        public List<SchoolClass> SchoolClassesWithTeachers { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public int ChoosenSchoolClassId { get; set; }
    }
}
