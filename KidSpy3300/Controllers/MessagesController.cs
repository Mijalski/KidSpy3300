using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Model;

namespace KidSpy3300.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public static int MessagesToRead = 3;

        private readonly DatabaseContext _context;
        private readonly IMessage _messages;
        
        public MessagesController(DatabaseContext context, IMessage messages)
        {
            _context = context;
            _messages = messages;
        }
        
       
        [HttpGet]
        public async Task<IActionResult> GetMessage(string id, int offset, bool inbound)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            bool isMore;

            var messages = inbound ? 
                _messages.GetForUserReceiving(id, offset, MessagesToRead, out isMore) :
                _messages.GetForUserSending(id, offset, MessagesToRead, out isMore);

            if (messages == null)
            {
                return NotFound();
            }

            
            var list = new List<Tuple<int, string, string>>();

            foreach (var m in messages)
            {
                list.Add(new Tuple<int, string, string>(m.Id, m.MessageTitle, $"{m.MessageTo.Name} {m.MessageTo.LastName}"));
            }

            if (isMore)
            {
                list.Add(new Tuple<int, string, string>(-1, "ISMORE","ISMORE"));
            }

            return Ok(list);
        }
    }
}