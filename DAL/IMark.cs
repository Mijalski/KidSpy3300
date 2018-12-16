using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IMark
    {
        Mark GetById(int id);
        void EditMark(int oldMarkId, Mark newMarkValues);
        List<Mark> GetForTeacherId(string id);
        List<Mark> GetForTeacherIdByMarkType(string id, MarkType markType);
        List<Mark> GetForStudentId(int id);
        List<Mark> GetForAssignmentId(int id);
    }
}
