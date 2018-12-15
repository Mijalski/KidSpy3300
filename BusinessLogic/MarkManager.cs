﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class MarkManager : IMark
    {
        private DatabaseContext context;

        public MarkManager(DatabaseContext _context)
        {
            context = _context;
        }

        public Mark GetById(int id)
        {
            return context.Marks.Single(_ => _.Id == id);
        }
        
        public List<Mark> GetForTeacherId(string id)
        {
            return context.Marks.Where(_ => _.Teacher.Id == id).ToList();
        }

        public List<Mark> GetForStudentId(int id)
        {
            return context.Students
                .Include(_ => _.Marks)
                .ThenInclude(_ => _.Assignment)
                .Single(_ => _.Id == id)
                .Marks
                .ToList();
        }

        public List<Mark> GetForAssignmentId(int id)
        {
            return context.Marks
                .Include(_ => _.Assignment)
                .Where(_ => _.Assignment.Id == id)
                .ToList();
        }
    }
}
