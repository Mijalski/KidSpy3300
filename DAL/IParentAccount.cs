using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IParentAccount
    {
        ParentAccount GetById(string id);
        void Add(ParentAccount newParentAccount);
    }
}
