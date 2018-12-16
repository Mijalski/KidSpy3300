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

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage([FromRoute] int id, [FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> PostMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return Ok(message);
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}