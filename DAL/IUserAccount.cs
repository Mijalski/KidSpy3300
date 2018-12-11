using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IUserAccount
    {
        UserAccount GetById(string id);
        UserAccount Get(string login);
    }
}
