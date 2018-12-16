using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class ManageAccountModel
    {
        public List<Message> MessagesOutbound;
        public List<Message> MessagesInbound;
        public List<Student> Students;
        public SchoolClass TeacherSchoolClass;
        public List<Assignment> AssignmentsNotGraded;
        public List<Assignment> AssignmentsGraded;
        public bool IsMoreIn;
        public bool IsMoreOut;
        public int Offset;
        public string UserId;
    }
}
