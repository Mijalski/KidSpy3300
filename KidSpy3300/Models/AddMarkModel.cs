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

        [Required]
        [Range(1,5)]
        public int MarkValue { get; set; }

        public string Description { get; set; }
        
    }
}
