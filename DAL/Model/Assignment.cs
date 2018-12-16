using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public SchoolClass SchoolClass { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool IsGraded { get; set; }

        public MarkType AverageMark { get; set; }
    }
}
