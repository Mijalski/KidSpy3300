using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IMessage
    {
        Message GetById(int id);
        List<Message> GetForUserId(int id);
        void Send(Message message);
        void Delete(Message message);
    }
}
