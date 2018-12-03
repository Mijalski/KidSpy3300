using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class ParentAccount : UserAccount
    {
        public  IEnumerable<Student> Students { get; set; }
    }
}
