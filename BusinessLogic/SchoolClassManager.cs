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
    }
}
