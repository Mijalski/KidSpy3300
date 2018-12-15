using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IMessage
    {
        Message GetById(int id, string userId);
        List<Message> GetForUserSending(string id);
        List<Message> GetForUserReceiving(string id);
        void Send(Message message);
    }
}
