using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/JuvenileMember")]
    public class JveneilMembersController : Controller
    {
        private readonly LibProjectContext _context;

        public JveneilMembersController(LibProjectContext context)
        {
            _context = context;

            if (_context.JuvenileMember.Count() == 0)
            {
                _context.JuvenileMember.Add(new JuvenileMember {AdultId=1, FirstName = "John", LastName = "Doe", MidInit = "S", Suffix = "Jr", Birthdate = DateTime.Parse("2017-12-25 12:00"), InActive = null, InActiveDate = null });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<JuvenileMember> GetAll()
        {
            return _context.JuvenileMember.ToList();
        }

        [HttpGet("{id}", Name = "GetJuvenileMember")]
        public IActionResult GetById(long id)
        {
            var member = _context.JuvenileMember.FirstOrDefault(t => t.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return new ObjectResult(member);
        }

        [HttpPost]
        public IActionResult Create([FromBody] JuvenileMember member)
        {
            if (member == null)
            {
                return BadRequest();
            }

            _context.JuvenileMember.Add(member);
            _context.SaveChanges();

            return CreatedAtRoute("GetJuvenileMember", new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] JuvenileMember member)
        {
            if (member == null || member.Id != id)
            {
                return BadRequest();
            }

            var uMember = _context.JuvenileMember.FirstOrDefault(t => t.Id == id);
            if (uMember == null)
            {
                return NotFound();
            }

            uMember.AdultId = member.AdultId;
            uMember.FirstName = member.FirstName;
            uMember.MidInit = member.MidInit;
            uMember.LastName = member.LastName;
            uMember.Suffix = member.Suffix;
            uMember.Birthdate = member.Birthdate;
            uMember.InActive = member.InActive;
            uMember.InActiveDate = member.InActiveDate;

            _context.JuvenileMember.Update(uMember);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
