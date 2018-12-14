using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface ITeacherAccount
    {
        TeacherAccount GetById(string id);
        List<TeacherAccount> GetAll();
        List<TeacherAccount> GetAllForParent(string parentId);
        TeacherAccount GetByStudent(int id);
        TeacherAccount GetBySchoolClass(int id);
        void Add(TeacherAccount newTeacher);
    }
}
