using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class StudentManager : IStudent
    {
        private DatabaseContext context;

        public StudentManager(DatabaseContext _context)
        {
            context = _context;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Single(_ => _.Id == id);
        }

        public Student GetByMark(Mark mark)
        {
            return context.Students.Single(_ => _.Marks.Contains(mark));
        }

        public List<Student> GetForParent(string id)
        {
            var parent = context.ParentAccounts
                .Include(_ => _.Students)
                .ThenInclude(_ => _.SchoolClass)
                .ThenInclude(_ => _.TeacherAccount)
                .Single(_ => _.Id == id);

            return parent.Students.Where(_ => _.IsActive).ToList();
        }

        public void Add(Student newStudent)
        {
            newStudent.IsActive = true;
            context.Add(newStudent);
            context.SaveChanges();
        }

        public void AddNewMark(int studentId, Mark mark)
        {
            context.Add(mark);
            context.Students
                .Include(_ => _.Marks)
                .Single(_ => _.Id == studentId)
                .Marks.Add(mark);
            context.SaveChanges();
        }

        public List<Student> GetStudentsForSchoolClass(int id)
        {
            return context.Students.Where(_ => _.SchoolClass.Id == id && _.IsActive).ToList();
        }

        public void Deactivate(int id)
        {
            var student = context.Students.Single(_ => _.Id == id);
            student.IsActive = false;
            context.SaveChanges();
        }

        public void UpdateImage()
        {
            context.SaveChanges();
        }
    }
}
