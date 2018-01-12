using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibProject_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibProject_Api.Controllers
{
    [Route("api/Address")]
    public class AddressesController : Controller
    {
        private readonly LibProjectContext _context;

        public AddressesController(LibProjectContext context)
        {
            _context = context;

            if (_context.Address.Count() == 0)
            {
                _context.Address.Add(new Address { AddrTypeId = "H", AddrLn1 = "123 Main Street", AddrLn2 = null, City = "Seattle", State = "WA", Zip = "98117", InActive = null, InActiveDate = null});
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<Address> GetAll()
        {
            return _context.Address.ToList();
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public IActionResult GetById(long id)
        {
            var addr = _context.Address.FirstOrDefault(t => t.Id == id);
            if (addr == null)
            {
                return NotFound();
            }
            return new ObjectResult(addr);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Address addr)
        {
            if (addr == null)
            {
                return BadRequest();
            }

            _context.Address.Add(addr);
            _context.SaveChanges();

            return CreatedAtRoute("GetAddress", new { id = addr.Id }, addr);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Address addr)
        {
            if (addr == null || addr.Id != id)
            {
                return BadRequest();
            }

            var uAddr = _context.Address.FirstOrDefault(t => t.Id == id);
            if (uAddr == null)
            {
                return NotFound();
            }

            uAddr.AddrTypeId = addr.AddrTypeId;
            uAddr.AddrLn1 = addr.AddrLn1;
            uAddr.AddrLn2 = addr.AddrLn2;
            uAddr.City = addr.City;
            uAddr.State = addr.State;
            uAddr.Zip = addr.Zip;
            uAddr.InActive = addr.InActive;
            uAddr.InActiveDate = addr.InActiveDate;
        
            _context.Address.Update(uAddr);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
