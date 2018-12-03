using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public enum MarkType
    {
        A = 5,
        B = 4,
        C = 3,
        D = 2,
        E = 1
    }
    public class Mark
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public MarkType MarkType { get; set; }
        
        [Required]
        public TeacherAccount Teacher { get; set; }

        public DateTime MarkDate { get; set; }
    }
}
