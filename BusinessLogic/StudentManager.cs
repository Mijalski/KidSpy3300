using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    public class StudentManager : IStudent
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
            return context.Students.Single(_ => _.Id == id);
        }

        public List<Student> GetForParent(string id)
        {
            return context.ParentAccounts.Single(_ => _.Id == id).Students.ToList();
        }

        public void Add(Student newStudent, ParentAccount parent)
        {
            context.Add(newStudent);
            
        }

        public List<Student> GetStudentsForSchoolClass(int id)
        {
            return context.Students.Where(_ => _.SchoolClass.Id == id).ToList();
        }
    }
}
