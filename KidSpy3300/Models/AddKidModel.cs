﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.AspNetCore.Http;

namespace KidSpy3300.Models
{
    public class AddKidModel
    {
        public Student Student;

        [Required]
        [MinLength(3), MaxLength(20)]
        public string StudentName { get; set; }

        public List<SchoolClass> SchoolClassesWithTeachers { get; set; }
        
        [Required]
        public int ChoosenSchoolClassId { get; set; }
        
    }
}
