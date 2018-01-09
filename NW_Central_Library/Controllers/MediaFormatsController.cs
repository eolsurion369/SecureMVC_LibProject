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
    public class MediaFormatsController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaFormatsController(LibProjectContext context)
        {
            _context = context;
        }

    
        // GET: MediaFormats
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaFormat.ToListAsync());
        }

        // GET: MediaFormats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFormat = await _context.MediaFormat
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mediaFormat == null)
            {
                return NotFound();
            }

            return View(mediaFormat);
        }

        [Authorize]
        // GET: MediaFormats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediaFormats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Format,InActive,InActiveDate")] MediaFormat mediaFormat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaFormat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaFormat);
        }

        // GET: MediaFormats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFormat = await _context.MediaFormat.SingleOrDefaultAsync(m => m.Id == id);
            if (mediaFormat == null)
            {
                return NotFound();
            }
            return View(mediaFormat);
        }

        // POST: MediaFormats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Format,InActive,InActiveDate")] MediaFormat mediaFormat)
        {
            if (id != mediaFormat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaFormat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaFormatExists(mediaFormat.Id))
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
            return View(mediaFormat);
        }

        // GET: MediaFormats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaFormat = await _context.MediaFormat
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mediaFormat == null)
            {
                return NotFound();
            }

            return View(mediaFormat);
        }

        // POST: MediaFormats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mediaFormat = await _context.MediaFormat.SingleOrDefaultAsync(m => m.Id == id);
            _context.MediaFormat.Remove(mediaFormat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaFormatExists(string id)
        {
            return _context.MediaFormat.Any(e => e.Id == id);
        }
    }
}
