using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;

namespace DAL
{
    public interface IMessage
    {
        Message GetById(int id, string userId);
        List<Message> GetForUserSending(string id, int offset, int amount, out bool isMore);
        List<Message> GetForUserReceiving(string id, int offset, int amount, out bool isMore);
        void Send(Message message);
    }
}
