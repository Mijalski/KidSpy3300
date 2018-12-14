using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class SchoolClassManager : ISchoolClass
    {
        private DatabaseContext context;

        public SchoolClassManager(DatabaseContext _context)
        {
            context = _context;
        }

        public List<SchoolClass> GetAll()
        {
            return context.SchoolClasses.ToList();
        }

        public List<SchoolClass> GetAllNotTaken()
        {
            return context.SchoolClasses.Where(_ => _.TeacherAccount == null).ToList();
        }

        public List<SchoolClass> GetAllTaken()
        {
            return context.SchoolClasses.Where(_ => _.TeacherAccount != null).Include(_ => _.TeacherAccount).ToList();
        }

        public SchoolClass GetById(int id)
        {
            return context.SchoolClasses.Single(_ => _.Id == id);
        }

        public SchoolClass GetByTeacher(string id)
        {
            return context.SchoolClasses.Include(_ => _.TeacherAccount).Single(_ => _.TeacherAccount.Id == id);
        }


        public void Add(SchoolClass newSchoolClass)
        {
            context.Add(newSchoolClass);
            context.SaveChanges();
        }

        public void Delete(SchoolClass oldSchoolClass)
        {
            context.Remove(oldSchoolClass);
            context.SaveChanges();
        }
    }
}
