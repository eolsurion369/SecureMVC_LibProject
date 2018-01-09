using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NW_Central_Library.Models.LibraryModels;

namespace NW_Central_Library.Controllers
{
    public class MemberPhonesController : Controller
    {
        private readonly LibProjectContext _context;

        public MemberPhonesController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: MemberPhones
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.MemberPhone.Include(m => m.Adult).Include(m => m.JuvenileMember).Include(m => m.Phone).Include(m => m.PhoneType);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: MemberPhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberPhone = await _context.MemberPhone
                .Include(m => m.Adult)
                .Include(m => m.JuvenileMember)
                .Include(m => m.Phone)
                .Include(m => m.PhoneType)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (memberPhone == null)
            {
                return NotFound();
            }

            return View(memberPhone);
        }

        [Authorize]
        // GET: MemberPhones/Create
        public IActionResult Create()
        {
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName");
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName");
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "PhoneNum");
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneType, "Id", "Id");
            return View();
        }

        // POST: MemberPhones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdultId,JuvenileId,PhoneId,PhoneTypeId")] MemberPhone memberPhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", memberPhone.AdultId);
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName", memberPhone.JuvenileId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "PhoneNum", memberPhone.PhoneId);
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneType, "Id", "Id", memberPhone.PhoneTypeId);
            return View(memberPhone);
        }

        // GET: MemberPhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberPhone = await _context.MemberPhone.SingleOrDefaultAsync(m => m.AdultId == id);
            if (memberPhone == null)
            {
                return NotFound();
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", memberPhone.AdultId);
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName", memberPhone.JuvenileId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "PhoneNum", memberPhone.PhoneId);
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneType, "Id", "Id", memberPhone.PhoneTypeId);
            return View(memberPhone);
        }

        // POST: MemberPhones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdultId,JuvenileId,PhoneId,PhoneTypeId")] MemberPhone memberPhone)
        {
            if (id != memberPhone.AdultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberPhoneExists(memberPhone.AdultId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", memberPhone.AdultId);
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName", memberPhone.JuvenileId);
            ViewData["PhoneId"] = new SelectList(_context.Phone, "Id", "PhoneNum", memberPhone.PhoneId);
            ViewData["PhoneTypeId"] = new SelectList(_context.PhoneType, "Id", "Id", memberPhone.PhoneTypeId);
            return View(memberPhone);
        }

        // GET: MemberPhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberPhone = await _context.MemberPhone
                .Include(m => m.Adult)
                .Include(m => m.JuvenileMember)
                .Include(m => m.Phone)
                .Include(m => m.PhoneType)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (memberPhone == null)
            {
                return NotFound();
            }

            return View(memberPhone);
        }

        // POST: MemberPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberPhone = await _context.MemberPhone.SingleOrDefaultAsync(m => m.AdultId == id);
            _context.MemberPhone.Remove(memberPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberPhoneExists(int id)
        {
            return _context.MemberPhone.Any(e => e.AdultId == id);
        }
    }
}
