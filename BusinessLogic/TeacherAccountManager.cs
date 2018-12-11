using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    public class TeacherAccountManager : ITeacherAccount
    {
        private DatabaseContext context;
        
        public TeacherAccountManager(DatabaseContext _context)
        {
            context = _context;
        }

        public TeacherAccount GetById(string id)
        {
            return context.TeacherAccounts.Single(_ => _.Id == id);
        }

        public TeacherAccount GetBySchoolClass(int id)
        {
            return context.SchoolClasses.Single(_ => _.Id == id).TeacherAccount;
        }
        
        public void Add(TeacherAccount newTeacher)
        {
            context.Add(newTeacher);
        }
    }
}
