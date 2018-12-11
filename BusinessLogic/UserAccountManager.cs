using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    public class UserAccountManager : IUserAccount
    {
        private DatabaseContext context;

        public UserAccountManager(DatabaseContext _context)
        {
            context = _context;
        }

        public UserAccount GetById(string id)
        {
            throw new NotImplementedException();
        }

        public UserAccount Get(string login)
        {
            return context.TeacherAccounts.Single(_ => _.UserName == login);
        }
    }
}
