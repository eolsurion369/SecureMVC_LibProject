using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/AdultMember")]
    public class AdultMembersController : Controller
    {
        private readonly LibProjectContext _context;

        public AdultMembersController(LibProjectContext context)
        {
            _context = context;

            if (_context.AdultMember.Count() == 0)
            {
                _context.AdultMember.Add(new AdultMember { FirstName = "John", LastName = "Doe", MidInit = "S", Suffix = null, Birthdate = DateTime.Parse("2000-12-25 12:00"), InActive = null, InActiveDate = null });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<AdultMember> GetAll()
        {
            return _context.AdultMember.ToList();
        }

        [HttpGet("{id}", Name = "GetAdultMember")]
        public IActionResult GetById(long id)
        {
            var member = _context.AdultMember.FirstOrDefault(t => t.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return new ObjectResult(member);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AdultMember member)
        {
            if (member == null)
            {
                return BadRequest();
            }

            _context.AdultMember.Add(member);
            _context.SaveChanges();

            return CreatedAtRoute("GetAdultMember", new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] AdultMember member)
        {
            if (member == null || member.Id != id)
            {
                return BadRequest();
            }

            var uMember = _context.AdultMember.FirstOrDefault(t => t.Id == id);
            if (uMember == null)
            {
                return NotFound();
            }

            uMember.FirstName = member.FirstName;
            uMember.MidInit = member.MidInit;
            uMember.LastName = member.LastName;
            uMember.Suffix = member.Suffix;
            uMember.Birthdate = member.Birthdate;
            uMember.InActive = member.InActive;
            uMember.InActiveDate = member.InActiveDate;

            _context.AdultMember.Update(uMember);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
