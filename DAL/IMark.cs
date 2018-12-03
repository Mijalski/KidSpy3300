using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IMark
    {
        Mark GetById(int id);
        IEnumerable<Mark> GetForStudentId(int id);
        IEnumerable<Mark> GetForTeacherId(int id);
        void Add(Mark newMark);
    }
}
