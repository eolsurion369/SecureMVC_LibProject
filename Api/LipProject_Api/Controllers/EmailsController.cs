using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/Email")]
    public class EmailsController : Controller
    {
        private readonly LibProjectContext _context;

        public EmailsController(LibProjectContext context)
        {
            _context = context;

            if (_context.Email.Count() == 0)
            {
                _context.Email.Add(new Email {Addr = "johndoe@yahoo.com" });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<Email> GetAll()
        {
            return _context.Email.ToList();
        }

        [HttpGet("{id}", Name = "GetEmail")]
        public IActionResult GetById(long id)
        {
            var EMail = _context.Email.FirstOrDefault(t => t.Id == id);
            if (EMail == null)
            {
                return NotFound();
            }
            return new ObjectResult(EMail);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Email EMail)
        {
            if (EMail == null)
            {
                return BadRequest();
            }

            _context.Email.Add(EMail);
            _context.SaveChanges();

            return CreatedAtRoute("GetEmail", new { id = EMail.Id }, EMail);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Email EMail)
        {
            if (EMail == null || EMail.Id != id)
            {
                return BadRequest();
            }

            var uEMail = _context.Email.FirstOrDefault(t => t.Id == id);
            if (uEMail == null)
            {
                return NotFound();
            }
            
            uEMail.Addr = EMail.Addr;
            uEMail.InActive = EMail.InActive;
            uEMail.InActiveDate = uEMail.InActiveDate;

            _context.Email.Update(uEMail);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
