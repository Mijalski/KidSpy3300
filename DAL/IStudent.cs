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
        Student GetByMark(Mark mark);
        List<Student> GetForParent(string id);
        void Add(Student newStudent);
        void AddNewMark(int studentId, Mark mark);
        List<Student> GetStudentsForSchoolClass(int id);
        void Deactivate(int id);
    }
}
