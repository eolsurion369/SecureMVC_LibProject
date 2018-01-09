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
    public class MediaTypeFormatsController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaTypeFormatsController(LibProjectContext context)
        {
            _context = context;
        }

    
        // GET: MediaTypeFormats
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.MediaTypeFormat.Include(m => m.MediaFormat).Include(m => m.MediaType);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: MediaTypeFormats/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaTypeFormat = await _context.MediaTypeFormat
                .Include(m => m.MediaFormat)
                .Include(m => m.MediaType)
                .SingleOrDefaultAsync(m => m.MediaTypeId == id);
            if (mediaTypeFormat == null)
            {
                return NotFound();
            }

            return View(mediaTypeFormat);
        }

        [Authorize]
        // GET: MediaTypeFormats/Create
        public IActionResult Create()
        {
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Id");
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id");
            return View();
        }

        // POST: MediaTypeFormats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaTypeId,MediaFormatId")] MediaTypeFormat mediaTypeFormat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaTypeFormat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Id", mediaTypeFormat.MediaFormatId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaTypeFormat.MediaTypeId);
            return View(mediaTypeFormat);
        }

        // GET: MediaTypeFormats/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaTypeFormat = await _context.MediaTypeFormat.SingleOrDefaultAsync(m => m.MediaTypeId == id);
            if (mediaTypeFormat == null)
            {
                return NotFound();
            }
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Id", mediaTypeFormat.MediaFormatId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaTypeFormat.MediaTypeId);
            return View(mediaTypeFormat);
        }

        // POST: MediaTypeFormats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MediaTypeId,MediaFormatId")] MediaTypeFormat mediaTypeFormat)
        {
            if (id != mediaTypeFormat.MediaTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaTypeFormat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaTypeFormatExists(mediaTypeFormat.MediaTypeId))
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
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Id", mediaTypeFormat.MediaFormatId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaTypeFormat.MediaTypeId);
            return View(mediaTypeFormat);
        }

        // GET: MediaTypeFormats/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaTypeFormat = await _context.MediaTypeFormat
                .Include(m => m.MediaFormat)
                .Include(m => m.MediaType)
                .SingleOrDefaultAsync(m => m.MediaTypeId == id);
            if (mediaTypeFormat == null)
            {
                return NotFound();
            }

            return View(mediaTypeFormat);
        }

        // POST: MediaTypeFormats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mediaTypeFormat = await _context.MediaTypeFormat.SingleOrDefaultAsync(m => m.MediaTypeId == id);
            _context.MediaTypeFormat.Remove(mediaTypeFormat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaTypeFormatExists(string id)
        {
            return _context.MediaTypeFormat.Any(e => e.MediaTypeId == id);
        }
    }
}
