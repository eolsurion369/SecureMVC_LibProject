﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibProject_Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LipProject_Api.Controllers
{

    public class JuvenileCheckOutsController : Controller
    {
        private readonly LibProjectContext _context;

        public JuvenileCheckOutsController(LibProjectContext context)
        {
            _context = context;

            if (_context.CheckOut.Count() == 0)
            {
                _context.CheckOut.Add(new CheckOut { AdultId = 1, JuvenileId = 1, MediaCopyId = 23, DueDate = DateTime.Parse("2018-01-13"), CheckedInDate = null } );
                _context.SaveChanges();

            }
        }

        [Route("api/J_CheckOut")]
        [HttpGet]
        public IEnumerable<CheckOut> GetAll()
        {
            return _context.CheckOut.ToList();
        }

        [Route("api/J_CheckOut/{adultMemberID}/{juvenileMemberID}")]
        public IActionResult GetById(long adultMemberID, long juvenileMemberID)
        {
            var cOut = _context.CheckOut.FirstOrDefault(t => t.AdultId == adultMemberID && t.JuvenileId == juvenileMemberID);
            if (cOut == null)
            {
                return NotFound();
            }
            return new ObjectResult(cOut);
        }

        [Route("api/A_CheckOut/{adultMemberID}/{juvenileMemberID}/MediaCopy/{mediaCopyID}")]
        [HttpGet("{adultMemberId}", Name = "GetCheckOut")]
        public IActionResult GetByIds(long adultMemberID, long juvenileMemberID, long mediaCopyID)
        {
            var cOut = _context.CheckOut.FirstOrDefault(t => t.AdultId == adultMemberID && t.JuvenileId == juvenileMemberID && t.MediaCopyId == mediaCopyID);
            if (cOut == null)
            {
                return NotFound();
            }
            return new ObjectResult(cOut);
        }

        [Route("api/createJ_CheckOut")]
        [HttpPost]
        public IActionResult Create([FromBody] CheckOut cOut)
        {
            if (cOut == null)
            {
                return BadRequest();
            }

            _context.CheckOut.Add(cOut);
            _context.SaveChanges();

            return CreatedAtRoute("GetCheckOut", new { adultMemberID = cOut.AdultId, juvenileMemberID = cOut.JuvenileId, mediaCopyID = cOut.MediaCopyId }, cOut);
        }

        [Route("api/updateA_CheckOut/{adultMemberID}/{juvenileMemberID}/MediaCopy/{mediaCopyID}")]
        [HttpPut("{adultMemberID}")]
        public IActionResult Update(long adultMemberID, long juvenileMemberID, long mediaCopyID, [FromBody] CheckOut cOut)
        {
            if (cOut == null || (cOut.AdultId != adultMemberID && cOut.JuvenileId == juvenileMemberID && cOut.MediaCopyId != mediaCopyID))
            {
                return BadRequest();
            }

            var uCout = _context.CheckOut.FirstOrDefault(t => t.AdultId == adultMemberID && t.MediaCopyId == mediaCopyID);
            if (uCout == null)
            {
                return NotFound();
            }

            uCout.AdultId = cOut.AdultId;
            uCout.JuvenileId = cOut.JuvenileId;
            uCout.MediaCopyId = cOut.MediaCopyId;
            uCout.DueDate = cOut.DueDate;
            uCout.CheckedInDate = cOut.CheckedInDate;

            _context.CheckOut.Update(uCout);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
