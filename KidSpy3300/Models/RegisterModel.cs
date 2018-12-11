using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class RegisterModel
    {
        public string LoginLogin { get; set; }
        public string LoginPassword { get; set; }

        public IEnumerable<SchoolClassModel> SchoolClasses { get; set; }

        public bool isTeacher { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"(\S){3,}@(\S){2,}\.(\S){2,}")]
        public string RegisterLogin { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string RegisterPassword { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        public int TeacherSchoolClassId { get; set; }
    }
}
