using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IParentAccount
    {
        ParentAccount GetById(string id);
        ParentAccount GetByStudent(Student student);
        void Add(ParentAccount newParentAccount);
        void AddNewStudent(string id, Student student);
    }
}
