using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface ITeacherAccount
    {
        TeacherAccount GetById(int id);
        TeacherAccount GetBySchoolClass(int id);
        SchoolClass GetSchoolClass(int id);
        void Add(TeacherAccount newTeacher);
        void Delete(TeacherAccount oldTeacher);
    }
}
