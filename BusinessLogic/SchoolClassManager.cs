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

        public List<SchoolClass> GetAll()
        {
            return context.SchoolClasses.ToList();
        }

        public List<SchoolClass> GetAllNotTaken()
        {
            return context.SchoolClasses.Where(_ => _.TeacherAccount == null).ToList();
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
    }
}
