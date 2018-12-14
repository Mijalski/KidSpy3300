using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

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
        
        public List<TeacherAccount> GetAll()
        {
            return context.TeacherAccounts.ToList();
        }

        public List<TeacherAccount> GetAllForParent(string parentId)
        {
            var teachersList = new List<TeacherAccount>();
            var parent = context.ParentAccounts
                .Include(_ => _.Students)
                .ThenInclude(_ => _.SchoolClass)
                .ThenInclude(_ => _.TeacherAccount)
                .Single(_ => _.Id == parentId);

            foreach (var kid in parent.Students)
            {
                teachersList.Add(kid.SchoolClass.TeacherAccount);
            }

            return teachersList;
        }

        public TeacherAccount GetBySchoolClass(int id)
        {
            return context.SchoolClasses.Single(_ => _.Id == id).TeacherAccount;
        }

        public TeacherAccount GetByStudent(int id)
        {
            return context.Students
                .Include(_ => _.SchoolClass)
                .ThenInclude(_ => _.TeacherAccount)
                .Single(_ => _.Id == id)
                .SchoolClass.TeacherAccount;
        }
        
        public void Add(TeacherAccount newTeacher)
        {
            context.Add(newTeacher);
            context.SaveChanges();
        }
    }
}
