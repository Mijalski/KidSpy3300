using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface ISchoolClass
    {
        List<SchoolClass> GetAll();
        List<SchoolClass> GetAllNotTaken();
        SchoolClass GetById(int id);
        void Add(SchoolClass newSchoolClass);
        void Delete(SchoolClass oldSchoolClass);
    }
}
