using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DAL.Model
{
    public enum UserAccountType
    {
        TeacherAccount = 0,
        ParentAccount = 1
    }

    public abstract class UserAccount : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}
