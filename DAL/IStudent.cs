using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IStudent
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student newStudent, ParentAccount parent);
        List<Mark> GetMarks(int id);
        SchoolClass GetClass(int id);
        void Add(Student newStudent);
    }
}
