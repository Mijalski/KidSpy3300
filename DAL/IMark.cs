using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IMark
    {
        Mark GetById(int id);
        List<Mark> GetForStudentId(int id);
        List<Mark> GetForTeacherId(int id);
        void Add(Mark newMark);
    }
}
