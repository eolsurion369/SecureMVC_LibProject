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
    public class MediaContentsController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaContentsController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: MediaContents
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.MediaContent.Include(m => m.Media);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: MediaContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContent
                .Include(m => m.Media)
                .SingleOrDefaultAsync(m => m.ContentId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }

            return View(mediaContent);
        }

        [Authorize]
        // GET: MediaContents/Create
        public IActionResult Create()
        {
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Author");
            return View();
        }

        // POST: MediaContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentId,MediaId,ContentItemOrder,ContentItem")] MediaContent mediaContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Author", mediaContent.MediaId);
            return View(mediaContent);
        }

        // GET: MediaContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContent.SingleOrDefaultAsync(m => m.ContentId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Author", mediaContent.MediaId);
            return View(mediaContent);
        }

        // POST: MediaContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContentId,MediaId,ContentItemOrder,ContentItem")] MediaContent mediaContent)
        {
            if (id != mediaContent.ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaContentExists(mediaContent.ContentId))
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
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Author", mediaContent.MediaId);
            return View(mediaContent);
        }

        // GET: MediaContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaContent = await _context.MediaContent
                .Include(m => m.Media)
                .SingleOrDefaultAsync(m => m.ContentId == id);
            if (mediaContent == null)
            {
                return NotFound();
            }

            return View(mediaContent);
        }

        // POST: MediaContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaContent = await _context.MediaContent.SingleOrDefaultAsync(m => m.ContentId == id);
            _context.MediaContent.Remove(mediaContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaContentExists(int id)
        {
            return _context.MediaContent.Any(e => e.ContentId == id);
        }
    }
}
