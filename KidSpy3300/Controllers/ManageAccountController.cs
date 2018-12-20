using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using KidSpy3300.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace KidSpy3300.Controllers
{
    public class ManageAccountController : Controller
    {
        public static int MessagesToRead = 3;

        private readonly IStudent _students;
        private readonly IMessage _messages;
        private readonly IMark _marks;
        private readonly ISchoolClass _schoolClasses;
        private readonly IParentAccount _parentAccounts;
        private readonly ITeacherAccount _teacherAccounts;
        private readonly IAssignment _assignments;
        private readonly UserManager<UserAccount> _userManager;
        private Task<UserAccount> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        public ManageAccountController(IStudent students, IMessage messages, ISchoolClass schoolClass, IMark marks, IAssignment assignments, IParentAccount parentAccounts, ITeacherAccount teacherAccounts, UserManager<UserAccount> userManager)
        {
            _schoolClasses = schoolClass;
            _messages = messages;
            _students = students;
            _userManager = userManager;
            _parentAccounts = parentAccounts;
            _teacherAccounts = teacherAccounts;
            _assignments = assignments;
            _marks = marks;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            return user is ParentAccount ?
                RedirectToAction("Parent","ManageAccount") :
                RedirectToAction("Teacher","ManageAccount"); 
        }
        
        [Authorize]
        public async Task<IActionResult> Parent()
        {
            var user = await GetCurrentUserAsync();

            if (user is ParentAccount)
            {
                var messagesIn = _messages.GetForUserReceiving(user.Id, 0, MessagesToRead, out var isMoreIn);
                var messagesOut = _messages.GetForUserSending(user.Id, 0, MessagesToRead, out var isMoreOut);
                var students = _students.GetForParent(user.Id);

                var model = new ManageAccountModel()
                {
                    MessagesInbound = messagesIn,
                    MessagesOutbound = messagesOut,
                    Students = students,
                    IsMoreIn = isMoreIn,
                    IsMoreOut = isMoreOut,
                    Offset = MessagesToRead,
                    UserId = user.Id
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Teacher()
        {
            var user = await GetCurrentUserAsync();

            if (user is TeacherAccount)
            {
                var sc = _schoolClasses.GetByTeacher(user.Id);
                var messagesIn = _messages.GetForUserReceiving(user.Id, 0, MessagesToRead, out var isMoreIn);
                var messagesOut = _messages.GetForUserSending(user.Id, 0, MessagesToRead, out var isMoreOut);
                var students = _students.GetStudentsForSchoolClass(sc.Id);
                var assignmentsGraded = _assignments.GetGradedForSchoolClassId(sc.Id);
                var assignmentsNotGraded = _assignments.GetNotGradedForSchoolClassId(sc.Id);

                var model = new ManageAccountModel()
                {
                    MessagesInbound = messagesIn,
                    MessagesOutbound = messagesOut,
                    Students = students,
                    TeacherSchoolClass = sc,
                    AssignmentsGraded = assignmentsGraded,
                    AssignmentsNotGraded = assignmentsNotGraded,
                    IsMoreIn = isMoreIn,
                    IsMoreOut = isMoreOut,
                    Offset = MessagesToRead,
                    UserId = user.Id
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        public async Task<IActionResult> AddKid(int kidId)
        {
            var user = await GetCurrentUserAsync();

            if (user is ParentAccount)
            {
                var sc = _schoolClasses.GetAllTaken();
                var student = kidId > 0 ?_students.GetById(kidId) : null;

                var model = new AddKidModel()
                {
                    SchoolClassesWithTeachers = sc,
                    Student = student 
                    
                };

                return View(model);
            }


            return RedirectToAction("Error", "Home");
            
        }

        
        [Authorize]
        public async Task<IActionResult> SendMessage(string userId)
        {
            var user = await GetCurrentUserAsync();

            if (user is ParentAccount parentAccount)
            {
                var teachers = _teacherAccounts.GetAllForParent(parentAccount.Id);
                var users = new List<UserAccount>();

                foreach (var teacher in teachers)
                {
                    users.Add(teacher);
                }

                var model = new SendMessageModel()
                {
                    UserAccounts = users,
                    PreSelectedId = string.IsNullOrEmpty(userId) ? null : _teacherAccounts.GetById(userId).Id
                };

                return View(model);
            }
            else if(user is TeacherAccount teacherAccount)
            {
                var sc = _schoolClasses.GetByTeacher(teacherAccount.Id);
                var students = _students.GetStudentsForSchoolClass(sc.Id);
                
                var users = new List<UserAccount>();

                foreach (var student in students)
                {
                    users.Add(_parentAccounts.GetByStudent(student));
                }

                var model = new SendMessageModel()
                {
                    UserAccounts = users,
                    PreSelectedId = string.IsNullOrEmpty(userId) ? null : _parentAccounts.GetById(userId).Id
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
            
        }

        [Authorize]
        public async Task<IActionResult> ShowMessage(int messageId)
        {
            var user = await GetCurrentUserAsync();
            
            var msg = _messages.GetById(messageId, user.Id);

            var model = new ShowMessageModel()
            {
                Message = msg,
                YourMessage = msg.MessageFrom.Id == user.Id
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ShowStudent(int studentId)
        {
            var user = await GetCurrentUserAsync();

            var student = _students.GetById(studentId);
            var marks = _marks.GetForStudentId(studentId);
            var teacher = _teacherAccounts.GetByStudent(studentId);
            var notGradedAssignments = _assignments.GetNotGradedForStudent(studentId);

            var model = new ShowStudentModel()
            {
                Student = student,
                Marks = marks,
                TeacherAccount = teacher,
                IsTeacher = user is TeacherAccount,
                Assignments = notGradedAssignments
            };

            return View(model);
        } 
        
        
        [Authorize]
        public async Task<IActionResult> AddMark(int studentId, int markId)
        {
            var user = await GetCurrentUserAsync();

            if (user is TeacherAccount teacher)
            {
                var student = _students.GetById(studentId);
                if (markId > 0)
                {
                    var mark = _marks.GetById(markId);

                    var model = new AddMarkModel()
                    {
                        Student = student,
                        MarkToEdit = mark
                    };
                    return View(model);
                }
                else
                {
                    var model = new AddMarkModel()
                    {
                        Student = student
                    };
                    return View(model);
                }
                
            }

            return RedirectToAction("Error", "Home");
        }
        
        [Authorize]
        public async Task<IActionResult> AddAssignment(int classId)
        {
            var user = await GetCurrentUserAsync();

            if (user is TeacherAccount teacher)
            {
                var sc = _schoolClasses.GetById(classId);

                var model = new AddAssignmentModel()
                {
                    ForSchoolClass = sc
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
        } 
        
        [Authorize]
        public async Task<IActionResult> GradeAssignment(int assignmentId)
        {
            var user = await GetCurrentUserAsync();

            if (user is TeacherAccount teacher)
            {
                var assignment = _assignments.GetById(assignmentId);
                var students = _students.GetStudentsForSchoolClass(assignment.SchoolClass.Id);

                var model = new GradeAssignmentModel()
                {
                    Assignment = assignment,
                    Students = students
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        public async Task<IActionResult> ShowAssignment(int assignmentId)
        {
            var user = await GetCurrentUserAsync();

            if (user is TeacherAccount)
            {
                var assignment = _assignments.GetById(assignmentId);
                var marks = _marks.GetForAssignmentId(assignmentId);
                var students = new List<Student>();
                foreach (var mark in marks)
                {
                    students.Add(_students.GetByMark(mark));
                }

                var model = new ShowAssignmentModel()
                {
                    Assignment = assignment,
                    Students = students,
                    Marks = marks
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
        }
        
        [Authorize]
        public async Task<IActionResult> ShowRaport(int classId)
        {
            var user = await GetCurrentUserAsync();

            if (user is TeacherAccount teacher)
            {
                var students = _students.GetStudentsForSchoolClass(classId);
                var teacherId = teacher.Id;
                var markNumber = _marks.GetForTeacherId(teacherId).Count;
                var sc = _schoolClasses.GetById(classId);
                var assignmentsGraded = _assignments.GetGradedForSchoolClassId(sc.Id);
                var assignmentsNotGraded = _assignments.GetNotGradedForSchoolClassId(sc.Id);
                var assignmentsTotal = assignmentsGraded.Count + assignmentsNotGraded.Count;

                var model = new ShowRaportModel()
                {
                    Students = students,
                    AssignmentsTotal = assignmentsTotal,
                    AssignmentsGraded = assignmentsGraded,
                    AssignmentsNotGraded = assignmentsNotGraded,
                    MarksA = _marks.GetForTeacherIdByMarkType(teacherId, MarkType.A),
                    MarksB = _marks.GetForTeacherIdByMarkType(teacherId, MarkType.B),
                    MarksC = _marks.GetForTeacherIdByMarkType(teacherId, MarkType.C),
                    MarksD = _marks.GetForTeacherIdByMarkType(teacherId, MarkType.D),
                    MarksE = _marks.GetForTeacherIdByMarkType(teacherId, MarkType.E),
                    MarksTotal = markNumber,
                    SchoolClass = sc
                };

                return View(model);
            }

            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        public async Task<IActionResult> DeleteStudentSubmit(int studentId)
        {
            var user = await GetCurrentUserAsync();

            if (user is ParentAccount parent)
            {
                var pStudents = _students.GetForParent(parent.Id);
                var student = _students.GetById(studentId);

                if (pStudents.Contains(student)) 
                {
                    _students.Deactivate(studentId);
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Error", "Home");
        }


        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMarkSubmit(AddMarkModel model, int studentId, int markId)
        {
            if (ModelState.IsValid && model.MarkValue > 0 )
            {
                var user = await GetCurrentUserAsync();

                if (user is TeacherAccount teacherAccount)
                {
                    var mark = new Mark()
                    {
                        Teacher = teacherAccount,
                        MarkType = (MarkType) model.MarkValue,
                        Description = model.Description,
                        MarkDate = DateTime.Now
                    };

                    if (markId == 0)
                    {
                        _students.AddNewMark(studentId, mark);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _marks.EditMark(markId, mark);
                        var markNew = _marks.GetById(markId);

                        if (markNew.Assignment != null)
                        {
                            var assignmentId = markNew.Assignment.Id;
                            var marks = _marks.GetForAssignmentId(assignmentId);
                            var total = 0;
                            foreach (var m in marks)
                            {
                                total += (int)m.MarkType;
                            }

                            _assignments.SetGraded(markNew.Assignment,total/marks.Count);
                        }

                        return RedirectToAction("Index");
                    }
                }
            }
            
            return RedirectToAction("Error", "Home");
        }
        
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddKidSubmit(AddKidModel model, int kidId, IFormFile avatarImage)
        {
            if (ModelState.IsValid && model.ChoosenSchoolClassId>0)
            {
                var user = await GetCurrentUserAsync();

                if (user is ParentAccount parentAccount)
                {
                        var newStudent = new Student()
                        {
                            Name = model.StudentName,
                            LastName = parentAccount.LastName,
                            SchoolClass = _schoolClasses.GetById(model.ChoosenSchoolClassId)
                        };

                        if (avatarImage != null)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await avatarImage.CopyToAsync(memoryStream);
                                newStudent.AvatarImage = memoryStream.ToArray();
                            }
                        }

                        _students.Add(newStudent);
                        _parentAccounts.AddNewStudent(parentAccount.Id, newStudent);

                        return RedirectToAction("Index");

                }
            }
            var student = _students.GetById(kidId);
            if (student != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await avatarImage.CopyToAsync(memoryStream);
                    student.AvatarImage = memoryStream.ToArray();
                }

                _students.UpdateImage();
            }

            return RedirectToAction("Error", "Home");
        }
        
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  SendMessageSubmit(SendMessageModel model)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(model.ToUserId))
            {
                var user = await GetCurrentUserAsync();
                var toUser = user is ParentAccount ? (UserAccount) _teacherAccounts.GetById(model.ToUserId) : _parentAccounts.GetById(model.ToUserId);
                var newMsg = new Message()
                {
                    MessageTitle = model.MessageTitle,
                    MessageContent = model.MessageContent,
                    MessageTo = toUser,
                    MessageFrom = user,
                    MessageDate = DateTime.Now,
                    Status = Status.Sent
                };

                _messages.Send(newMsg);
                
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAssignmentSubmit(AddAssignmentModel model)
        {
            if (ModelState.IsValid && model.DueDateTime is DateTime && model.DueDateTime > DateTime.Now)
            {
                var user = await GetCurrentUserAsync();
                if (user is TeacherAccount)
                {
                    var sc = _schoolClasses.GetByTeacher(user.Id);
                    var assignment = new Assignment()
                    {
                        SchoolClass = sc,
                        DateTime = DateTime.Now,
                        DueDate = model.DueDateTime,
                        Name = model.AssignmentName
                    };

                    _assignments.Add(assignment);

                    return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Error", "Home");
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GradeAssignmentSubmit(GradeAssignmentModel model, int assigmentId)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                if (user is TeacherAccount teacher)
                {
                    var assignment = _assignments.GetById(assigmentId);
                    var total = 0;
                    for(var i = 0; i < model.StudentIds.Count;i++)
                    {
                        var mark = new Mark()
                        {
                            Assignment = assignment,
                            Description = "",
                            MarkDate = DateTime.Now,
                            MarkType = model.Marks[i],
                            Teacher = teacher
                        };
                        total += (int)mark.MarkType;
                        _students.AddNewMark(model.StudentIds[i], mark);
                    }
                    _assignments.SetGraded(assignment, total/model.StudentIds.Count);

                    return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Error", "Home");
        }
        
    }
}

