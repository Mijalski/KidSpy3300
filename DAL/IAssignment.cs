using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IAssignment
    {
        Assignment GetById(int id);
        List<Assignment> GetGradedForSchoolClassId(int id);
        List<Assignment> GetNotGradedForSchoolClassId(int id);
        void Add(Assignment assignment);
        void SetGraded(Assignment assignment, int averageMark);
        List<Assignment> GetForStudent(int id);
        List<Assignment> GetNotGradedForStudent(int id);
    }
}
