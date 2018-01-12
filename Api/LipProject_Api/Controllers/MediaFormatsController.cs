using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LipProject_Api.Controllers
{
    [Route("api/MediaFormat")]
    public class MediaFormatsController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaFormatsController(LibProjectContext context)
        {
            _context = context;

            if (_context.MediaFormat.Count() == 0)
            {
                _context.MediaFormat.Add(new MediaFormat { Id = "h", Format = "Hard Bound", InActive = null, InActiveDate = null });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<MediaType> GetAll()
        {
            return _context.MediaType.ToList();
        }

        [HttpGet("{id}", Name = "GetMediaFormat")]
        public IActionResult GetById(string id)
        {
            var mFormat = _context.MediaFormat.FirstOrDefault(t => t.Id == id);
            if (mFormat == null)
            {
                return NotFound();
            }
            return new ObjectResult(mFormat);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MediaFormat mFormat)
        {
            if (mFormat == null)
            {
                return BadRequest();
            }

            _context.MediaFormat.Add(mFormat);
            _context.SaveChanges();

            return CreatedAtRoute("GetMediaFormat", new { id = mFormat.Id }, mFormat);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] MediaFormat mFormat)
        {
            if (mFormat == null || mFormat.Id != id)
            {
                return BadRequest();
            }

            var uFormat = _context.MediaFormat.FirstOrDefault(t => t.Id == id);
            if (uFormat == null)
            {
                return NotFound();
            }

            uFormat.Format = mFormat.Format;
            uFormat.InActive = mFormat.InActive;
            uFormat.InActiveDate = mFormat.InActiveDate;

            _context.MediaFormat.Update(uFormat);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
