using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class AddMarkModel
    {
        public Student Student { get; set; }

        public Mark MarkToEdit { get; set; }
        
        public int MarkValue { get; set; }
        
        [MinLength(3), MaxLength(200)]
        public string Description { get; set; }
        
    }
}
