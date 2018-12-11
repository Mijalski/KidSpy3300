using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;

namespace BusinessLogic
{
    public class MessageManager : IMessage
    {
        private DatabaseContext context;

        public MessageManager(DatabaseContext _context)
        {
            context = _context;
        }

        public Message GetById(int id)
        {
            return context.Messages.Single(_ => _.Id == id);
        }

        public List<Message> GetForUserSending(string id)
        {
            return context.Messages.Where(_ => _.MessageFrom.Id == id).ToList();
        }

        public List<Message> GetForUserReceiving(string id)
        {
            return context.Messages.Where(_ => _.MessageTo.Id == id).ToList();
        }

        public void Send(Message message)
        {
            context.Add(message);
        }
    }
}
