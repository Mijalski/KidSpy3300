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

        public Message GetById(int id, string userId)
        {
            var message = context.Messages.Include(_ => _.MessageFrom).Include(_ => _.MessageTo).Single(_ => _.Id == id);

            if (userId == message.MessageTo.Id)
            {
                message.Status = Status.Read;
                context.SaveChanges();
            }

            return message;
        }

        public List<Message> GetForUserSending(string id, int offset, int amount, out bool isMore)
        {
            isMore = context.Messages.Count(_ => _.MessageTo.Id == id) > offset + amount;

            return context.Messages
                .Include(_ => _.MessageFrom)
                .Include(_ => _.MessageTo)
                .Where(_ => _.MessageFrom.Id == id)
                .OrderByDescending(_ => _.MessageDate)
                .Skip(offset)
                .Take(amount)
                .ToList();
        }

        public List<Message> GetForUserReceiving(string id, int offset, int amount, out bool isMore)
        {
            var userMsgs = context
                .Messages.Include(_ => _.MessageFrom)
                .Include(_ => _.MessageTo)
                .Where(_ => _.MessageTo.Id == id)
                .OrderByDescending(_ => _.MessageDate)
                .Skip(offset)
                .Take(amount)
                .ToList();

            isMore = context.Messages.Count(_ => _.MessageTo.Id == id) > offset + amount;
            

            var undeliveredMessages = userMsgs.Where(_ => _.Status == Status.Sent).ToList();

            foreach (var um in undeliveredMessages)
            {
                um.Status = Status.Delivered;
            }

            context.SaveChanges();
            return userMsgs;
        }

        public void Send(Message message)
        {
            context.Add(message);
            context.SaveChanges();
        }
    }
}
