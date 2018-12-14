using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface ISchoolClass
    {
        SchoolClass GetByTeacher(string id);
        List<SchoolClass> GetAll();
        List<SchoolClass> GetAllNotTaken();
        List<SchoolClass> GetAllTaken();
        SchoolClass GetById(int id);
        void Add(SchoolClass newSchoolClass);
        void Delete(SchoolClass oldSchoolClass);
    }
}
