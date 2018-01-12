using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/Genre")]
    public class GenresController : Controller
    {
        private readonly LibProjectContext _context;

        public GenresController(LibProjectContext context)
        {
            _context = context;

            if (_context.Genre.Count() == 0)
            {
                _context.Genre.Add(new Genre { Id = "sf", Name = "Science Fiction" });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<Genre> GetAll()
        {
            return _context.Genre.ToList();
        }

        [HttpGet("{id}", Name = "GetGenre")]
        public IActionResult GetById(string id)
        {
            var gName = _context.Genre.FirstOrDefault(t => t.Id == id);
            if (gName == null)
            {
                return NotFound();
            }
            return new ObjectResult(gName);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Genre gName)
        {
            if (gName == null)
            {
                return BadRequest();
            }

            _context.Genre.Add(gName);
            _context.SaveChanges();

            return CreatedAtRoute("GetGenre", new { id = gName.Id }, gName);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Genre gName)
        {
            if (gName == null || gName.Id != id)
            {
                return BadRequest();
            }

            var uName = _context.Genre.FirstOrDefault(t => t.Id == id);
            if (uName == null)
            {
                return NotFound();
            }

            uName.Name = gName.Name;
            uName.InActive = gName.InActive;
            uName.InActiveDate = gName.InActiveDate;

            _context.Genre.Update(uName);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
