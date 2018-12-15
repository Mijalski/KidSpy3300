using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class AddAssignmentModel
    {
        [Required]
        [MinLength(3)]
        public string AssignmentName { get; set; }

        public SchoolClass ForSchoolClass { get; set; }
        
        [Required]
        public DateTime DueDateTime { get; set; }
    }
}
