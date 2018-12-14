using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class ParentAccount : UserAccount
    {
        public  List<Student> Students { get; set; }
    }
}
