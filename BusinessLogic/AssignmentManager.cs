using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class AssignmentManager : IAssignment
    {
        private DatabaseContext context;

        public AssignmentManager(DatabaseContext _context)
        {
            context = _context;
        }


        public Assignment GetById(int id)
        {
            return context.Assignments.Include(_ => _.SchoolClass).Single(_ => _.Id == id);
        }

        public List<Assignment> GetGradedForSchoolClassId(int id)
        {
            return context.Assignments.Include(_ => _.SchoolClass).Where(_ => _.SchoolClass.Id == id && _.IsGraded).ToList();
        }

        public List<Assignment> GetNotGradedForSchoolClassId(int id)
        {
            return context.Assignments.Include(_ => _.SchoolClass).Where(_ => _.SchoolClass.Id == id && !_.IsGraded).ToList();
        }

        public void Add(Assignment assignment)
        {
            assignment.IsGraded = false;
            context.Add(assignment);
            context.SaveChanges();
        }

        public void SetGraded(Assignment assignment)
        {
            assignment.IsGraded = true;
            context.SaveChanges();
        }

        public List<Assignment> GetForStudent(int id)
        {
            var student = context.Students.Include(_ => _.SchoolClass).Single(_ => _.Id == id);
            return context.Assignments.Include(_ => _.SchoolClass).Where(_ => _.SchoolClass.Id == student.SchoolClass.Id).ToList();
        }

        public List<Assignment> GetNotGradedForStudent(int id)
        {
            return GetForStudent(id).Where(_ => _.IsGraded == false).ToList();
        }
    }
}
