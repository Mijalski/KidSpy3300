using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IParentAccount
    {
        ParentAccount GetById(string id);
        ParentAccount GetByStudentId(int studentId);
        List<Student> GetChildren(int id);
        void Add(ParentAccount newParentAccount);
        void Delete(ParentAccount oldTeacherAccount);
    }
}
