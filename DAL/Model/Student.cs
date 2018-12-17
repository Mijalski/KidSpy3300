﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public byte[] AvatarImage { get; set; }

        [Required]
        public string LastName { get; set; }

        public SchoolClass SchoolClass { get; set; }
        
        //virtual will make them lazyload
        public virtual List<Mark> Marks { get; set; }

        public bool IsActive { get; set; }
    }
}
