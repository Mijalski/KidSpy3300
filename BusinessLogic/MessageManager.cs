using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

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
            var message = context.Messages.Include(_ => _.MessageFrom).Include(_ => _.MessageTo).Single(_ => _.Id == id);

            message.Status = Status.Read;
            context.SaveChanges();

            return message;
        }

        public List<Message> GetForUserSending(string id)
        {
            return context.Messages.Include(_ => _.MessageFrom).Include(_ => _.MessageTo).Where(_ => _.MessageFrom.Id == id).OrderByDescending(_ => _.MessageDate).ToList();
        }

        public List<Message> GetForUserReceiving(string id)
        {
            var messages = context.Messages.Include(_ => _.MessageFrom).Include(_ => _.MessageTo).Where(_ => _.MessageTo.Id == id).OrderByDescending(_ => _.MessageDate).ToList();
            var undeliveredMessages = messages.Where(_ => _.Status == Status.Sent).ToList();

            foreach (var um in undeliveredMessages)
            {
                um.Status = Status.Delivered;
            }

            context.SaveChanges();
            return messages;
        }

        public void Send(Message message)
        {
            context.Add(message);
            context.SaveChanges();
        }
    }
}
