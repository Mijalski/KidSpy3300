using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    class StudentManager : IStudent
    {
        private DatabaseContext context;

        public StudentManager(DatabaseContext _context)
        {
            context = _context;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.FirstOrDefault(_ => _.Id == id);
        }

        public void Add(Student newStudent, ParentAccount parent)
        {
            throw new NotImplementedException();
        }

        public List<Mark> GetMarks(int id)
        {
            throw new NotImplementedException();
        }

        public SchoolClass GetClass(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Student newStudent)
        {
            throw new NotImplementedException();
        }
    }
}
