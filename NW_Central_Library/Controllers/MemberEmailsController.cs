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
    public class MemberEmailsController : Controller
    {
        private readonly LibProjectContext _context;

        public MemberEmailsController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: MemberEmails
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.MemberEmail.Include(m => m.Adult).Include(m => m.Email).Include(m => m.JuvenileMember);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: MemberEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEmail = await _context.MemberEmail
                .Include(m => m.Adult)
                .Include(m => m.Email)
                .Include(m => m.JuvenileMember)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (memberEmail == null)
            {
                return NotFound();
            }

            return View(memberEmail);
        }

        [Authorize]
        // GET: MemberEmails/Create
        public IActionResult Create()
        {
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName");
            ViewData["EmailId"] = new SelectList(_context.Email, "Id", "Addr");
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName");
            return View();
        }

        // POST: MemberEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdultId,JuvenileId,EmailId")] MemberEmail memberEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", memberEmail.AdultId);
            ViewData["EmailId"] = new SelectList(_context.Email, "Id", "Addr", memberEmail.EmailId);
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName", memberEmail.JuvenileId);
            return View(memberEmail);
        }

        // GET: MemberEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEmail = await _context.MemberEmail.SingleOrDefaultAsync(m => m.AdultId == id);
            if (memberEmail == null)
            {
                return NotFound();
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", memberEmail.AdultId);
            ViewData["EmailId"] = new SelectList(_context.Email, "Id", "Addr", memberEmail.EmailId);
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName", memberEmail.JuvenileId);
            return View(memberEmail);
        }

        // POST: MemberEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdultId,JuvenileId,EmailId")] MemberEmail memberEmail)
        {
            if (id != memberEmail.AdultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberEmailExists(memberEmail.AdultId))
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
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", memberEmail.AdultId);
            ViewData["EmailId"] = new SelectList(_context.Email, "Id", "Addr", memberEmail.EmailId);
            ViewData["JuvenileId"] = new SelectList(_context.JuvenileMember, "Id", "FirstName", memberEmail.JuvenileId);
            return View(memberEmail);
        }

        // GET: MemberEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEmail = await _context.MemberEmail
                .Include(m => m.Adult)
                .Include(m => m.Email)
                .Include(m => m.JuvenileMember)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (memberEmail == null)
            {
                return NotFound();
            }

            return View(memberEmail);
        }

        // POST: MemberEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberEmail = await _context.MemberEmail.SingleOrDefaultAsync(m => m.AdultId == id);
            _context.MemberEmail.Remove(memberEmail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberEmailExists(int id)
        {
            return _context.MemberEmail.Any(e => e.AdultId == id);
        }
    }
}
