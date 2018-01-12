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
    public class CheckInsController : Controller
    {
        private readonly LibProjectContext _context;
        private object checkIns;

        public CheckInsController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: CheckIns
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.CheckIns.Include(c => c.Adult).Include(c => c.MediaCopy);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: CheckIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checIn = await _context.CheckIns
                .Include(c => c.Adult)
                .Include(c => c.MediaCopy)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (checkIns == null)
            {
                return NotFound();
            }

            return View(checkIns);
        }
        [Authorize]
        // GET: CheckIns/Create
        public IActionResult Create()
        {
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "Full Name");
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "Media Format Id");
            return View();
        }

        // POST: CheckOuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdultId,JuvenileId,MediaCopyId,DueDate,CheckedInDate")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", checkIn.AdultId);
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId", checkIn.MediaCopyId);
            return View(checkIn);
        }

        // GET: CheckIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIns.SingleOrDefaultAsync(m => m.AdultId == id);
            if (checkIn == null)
            {
                return NotFound();
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FullName", checkIn.AdultId);
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId", checkIn.MediaCopyId);
            return View(checkIn);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdultId,JuvenileId,MediaCopyId,DueDate,CheckedInDate")] CheckIn checkIn)
        {
            if (id != checkIn.AdultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckOutExists(checkIn.AdultId))
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
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", checkIn.AdultId);
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId", checkIn.MediaCopyId);
            return View(checkIn);
        }

        // GET: CheckIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIns
                .Include(c => c.Adult)
                .Include(c => c.MediaCopy)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return View(checkIn);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkOut = await _context.CheckIns.SingleOrDefaultAsync(m => m.AdultId == id);
            _context.CheckIns.Remove(checkOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInExists(int id)
        {
            return _context.CheckIns.Any(e => e.AdultId == id);
        }
    }
}
