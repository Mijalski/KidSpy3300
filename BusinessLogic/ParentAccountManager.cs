using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class ParentAccountManager : IParentAccount
    {
        private DatabaseContext context;
        
        public ParentAccountManager(DatabaseContext _context)
        {
            context = _context;
        }

        public ParentAccount GetById(string id)
        {
            return context.ParentAccounts.Single(_ => _.Id == id);
        }

        public ParentAccount GetByStudent(Student student)
        {
            return context.ParentAccounts.Single(_ => _.Students.Contains(student));
        }

        public void Add(ParentAccount newParentAccount)
        {
            context.Add(newParentAccount);
            context.SaveChanges();
        }

        public void AddNewStudent(string id, Student student)
        {
            var parent = context.ParentAccounts.Include(_ => _.Students).Single(_ => _.Id == id);

            parent.Students.Add(student);
            context.SaveChanges();
        }
        
    }
}
