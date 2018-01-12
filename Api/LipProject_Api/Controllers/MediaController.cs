using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/Media")]
    public class MediaController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaController(LibProjectContext context)
        {
            _context = context;

            if (_context.Media.Count() == 0)
            {
                _context.Media.Add(new Media { Title = "The Eye of the World", Author = "Robert Jordan", PublisherId = null, CopyRightDate = DateTime.Parse("1990-01-28 12:00"), Characteristics = "Pg 688", Summary = "In the Third Age, an age of prophecy when the world and time themselves hang in the balance, the Dark One, imprisoned by the Creator, is stirring in Shayol Ghul.", InActive = null, InActiveDate = null });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<Media> GetAll()
        {
            return _context.Media.ToList();
        }

        [HttpGet("{id}", Name = "GetMedia")]
        public IActionResult GetById(long id)
        {
            var media = _context.Media.FirstOrDefault(t => t.Id == id);
            if (media == null)
            {
                return NotFound();
            }
            return new ObjectResult(media);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Media media)
        {
            if (media == null)
            {
                return BadRequest();
            }

            _context.Media.Add(media);
            _context.SaveChanges();

            return CreatedAtRoute("GetMedia", new { id = media.Id }, media);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Media media)
        {
            if (media == null || media.Id != id)
            {
                return BadRequest();
            }

            var uMedia = _context.Media.FirstOrDefault(t => t.Id == id);
            if (uMedia == null)
            {
                return NotFound();
            }

            uMedia.Title = media.Title;
            uMedia.Author = media.Author;
            uMedia.PublisherId = media.PublisherId;
            uMedia.CopyRightDate = media.CopyRightDate;
            uMedia.Characteristics = media.Characteristics;
            uMedia.Summary = media.Summary;
            uMedia.InActive = media.InActive;
            uMedia.InActiveDate = media.InActiveDate;

            _context.Media.Update(uMedia);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
