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
    public class JuvenileMembersController : Controller
    {
        private readonly LibProjectContext _context;

        public JuvenileMembersController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: JuvenileMembers
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.JuvenileMember.Include(j => j.Adult);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: JuvenileMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juvenileMember = await _context.JuvenileMember
                .Include(j => j.Adult)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (juvenileMember == null)
            {
                return NotFound();
            }

            return View(juvenileMember);
        }

        [Authorize]
        // GET: JuvenileMembers/Create
        public IActionResult Create()
        {
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "First Name");
            return View();
        }

        // POST: JuvenileMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdultId,FirstName,LastName,MidInit,Suffix,Birthdate,InActive,InActiveDate")] JuvenileMember juvenileMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juvenileMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", juvenileMember.AdultId);
            return View(juvenileMember);
        }

        // GET: JuvenileMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juvenileMember = await _context.JuvenileMember.SingleOrDefaultAsync(m => m.Id == id);
            if (juvenileMember == null)
            {
                return NotFound();
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "First Name", juvenileMember.AdultId);
            return View(juvenileMember);
        }

        // POST: JuvenileMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdultId,FirstName,LastName,MidInit,Suffix,Birthdate,InActive,InActiveDate")] JuvenileMember juvenileMember)
        {
            if (id != juvenileMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juvenileMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuvenileMemberExists(juvenileMember.Id))
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
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", juvenileMember.AdultId);
            return View(juvenileMember);
        }

        // GET: JuvenileMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juvenileMember = await _context.JuvenileMember
                .Include(j => j.Adult)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (juvenileMember == null)
            {
                return NotFound();
            }

            return View(juvenileMember);
        }

        // POST: JuvenileMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juvenileMember = await _context.JuvenileMember.SingleOrDefaultAsync(m => m.Id == id);
            _context.JuvenileMember.Remove(juvenileMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuvenileMemberExists(int id)
        {
            return _context.JuvenileMember.Any(e => e.Id == id);
        }
    }
}
