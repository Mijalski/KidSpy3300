using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface ISchoolClass
    {
        IEnumerable<SchoolClass> GetAll();
        SchoolClass GetById(int id);
        void Add(SchoolClass newSchoolClass);
        void Delete(SchoolClass oldSchoolClass);
        IEnumerable<Student> GetStudents(int id);
        TeacherAccount GetTeacherAccount(int id);
    }
}
