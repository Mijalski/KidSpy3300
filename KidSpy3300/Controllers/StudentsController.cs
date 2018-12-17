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
    public class StudentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StudentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marks = _context.Students.Include(_ => _.Marks).Single(_ => _.Id == id).Marks.ToList();
            var list = new List<Tuple<int, string, string>>();

            foreach (var mark in marks)
            {
                list.Add(new Tuple<int, string, string>((int)mark.MarkType, mark.Description, mark.MarkDate.ToShortDateString()));
            }

            return Ok(list);
        }
    }
}