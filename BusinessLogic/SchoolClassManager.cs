using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    public class SchoolClassManager : ISchoolClass
    {
        private DatabaseContext context;

        public SchoolClassManager(DatabaseContext _context)
        {
            context = _context;
        }

        public IEnumerable<SchoolClass> GetAll()
        {
            return context.SchoolClasses;
        }

        public SchoolClass GetById(int id)
        {
            return context.SchoolClasses.FirstOrDefault(_ => _.Id == id);
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

        public IEnumerable<Student> GetStudents(int id)
        {
            return context.Students.Where(_ => _.SchoolClass.Id == id);
        }

        public TeacherAccount GetTeacherAccount(int id)
        {
            throw  new Exception("fasf");
            //return context.TeacherAccounts.Where(_ => _.Id == id);
        }
    }
}
