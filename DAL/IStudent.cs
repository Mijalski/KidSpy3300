using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student newStudent, ParentAccount parent);
        IEnumerable<Mark> GetMarks(int id);
        SchoolClass GetClass(int id);
        void Add(Student newStudent);
    }
}
