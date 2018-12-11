using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    public class ParentAccountManager : IParentAccount
    {
        private DatabaseContext context;
        
        public ParentAccountManager(DatabaseContext _context)
        {
            context = _context;
        }

        public ParentAccount GetById(string id)
        {
            return context.ParentAccounts.Single(_ => _.Id == id);
        }

        public void Add(ParentAccount newParentAccount)
        {
            context.Add(newParentAccount);
        }
        
        
    }
}
