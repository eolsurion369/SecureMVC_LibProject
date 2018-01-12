using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NW_Central_Library.Models.LibraryModels;

namespace NW_Central_Library.Controllers
{
    public class CheckInsController : Controller
    {
        private readonly LibProjectContext _context;

        public CheckInsController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: CheckIns
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.CheckOut.Include(c => c.Adult).Include(c => c.MediaCopy);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: CheckIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkOut = await _context.CheckOut
                .Include(c => c.Adult)
                .Include(c => c.MediaCopy)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (checkOut == null)
            {
                return NotFound();
            }

            return View(checkOut);
        }

        // GET: CheckIns/Create
        public IActionResult Create()
        {
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName");
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId");
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdultId,JuvenileId,MediaCopyId,DueDate,CheckedInDate")] CheckOut checkOut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkOut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", checkOut.AdultId);
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId", checkOut.MediaCopyId);
            return View(checkOut);
        }

        // GET: CheckIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkOut = await _context.CheckOut.SingleOrDefaultAsync(m => m.AdultId == id);
            if (checkOut == null)
            {
                return NotFound();
            }
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", checkOut.AdultId);
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId", checkOut.MediaCopyId);
            return View(checkOut);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdultId,JuvenileId,MediaCopyId,DueDate,CheckedInDate")] CheckOut checkOut)
        {
            if (id != checkOut.AdultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkOut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckOutExists(checkOut.AdultId))
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
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", checkOut.AdultId);
            ViewData["MediaCopyId"] = new SelectList(_context.MediaCopy, "Id", "MediaFormatId", checkOut.MediaCopyId);
            return View(checkOut);
        }

        // GET: CheckIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkOut = await _context.CheckOut
                .Include(c => c.Adult)
                .Include(c => c.MediaCopy)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (checkOut == null)
            {
                return NotFound();
            }

            return View(checkOut);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkOut = await _context.CheckOut.SingleOrDefaultAsync(m => m.AdultId == id);
            _context.CheckOut.Remove(checkOut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckOutExists(int id)
        {
            return _context.CheckOut.Any(e => e.AdultId == id);
        }
    }
}
