using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model
{
    public class TeacherAccount : UserAccount
    {
        public string Title { get; set; }
    }
}
