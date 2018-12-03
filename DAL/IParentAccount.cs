using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IParentAccount
    {
        ParentAccount GetById(int id);
        ParentAccount GetByStudentId(int studentId);
    }
}
