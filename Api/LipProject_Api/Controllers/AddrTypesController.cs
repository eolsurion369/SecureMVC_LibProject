using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/AddrType")]
    public class AddrTypesController : Controller
    {
        private readonly LibProjectContext _context;

        public AddrTypesController(LibProjectContext context)
        {
            _context = context;

            if (_context.AddrType.Count() == 0)
            {
                _context.AddrType.Add(new AddrType { Id = "h", Type="Home"});
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<AddrType> GetAll()
        {
            return _context.AddrType.ToList();
        }

        [HttpGet("{id}", Name = "GetAddrType")]
        public IActionResult GetById(string id)
        {
            var aType = _context.AddrType.FirstOrDefault(t => t.Id == id);
            if (aType == null)
            {
                return NotFound();
            }
            return new ObjectResult(aType);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddrType aType)
        {
            if (aType == null)
            {
                return BadRequest();
            }

            _context.AddrType.Add(aType);
            _context.SaveChanges();

            return CreatedAtRoute("GetAddrType", new { id = aType.Id }, aType);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] AddrType aType)
        {
            if (aType == null || aType.Id != id)
            {
                return BadRequest();
            }

            var uType = _context.AddrType.FirstOrDefault(t => t.Id == id);
            if (uType == null)
            {
                return NotFound();
            }

            uType.Type = aType.Type;
            uType.InActive = aType.InActive;
            uType.InActiveDate = aType.InActiveDate;

            _context.AddrType.Update(uType);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
