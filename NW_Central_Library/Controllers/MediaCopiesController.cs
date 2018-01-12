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
    public class MediaCopiesController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaCopiesController(LibProjectContext context)
        {
            _context = context;
        }


        // GET: MediaCopies
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.MediaCopy.Include(m => m.Media).Include(m => m.MediaFormat).Include(m => m.MediaGenre).Include(m => m.MediaType);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: MediaCopies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaCopy = await _context.MediaCopy
                .Include(m => m.Media)
                .Include(m => m.MediaFormat)
                .Include(m => m.MediaGenre)
                .Include(m => m.MediaType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mediaCopy == null)
            {
                return NotFound();
            }

            return View(mediaCopy);
        }

        [Authorize]
        // GET: MediaCopies/Create
        public IActionResult Create()
        {
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Title");
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Format");
            ViewData["MediaGenreId"] = new SelectList(_context.Genre, "Id", "Name");
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Type");
            return View();
        }

        // POST: MediaCopies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MediaId,MediaTypeId,MediaGenreId,MediaFormatId,CopyNumber,InActive,InActiveDate")] MediaCopy mediaCopy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaCopy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Author", mediaCopy.MediaId);
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Format", mediaCopy.MediaFormatId);
            ViewData["MediaGenreId"] = new SelectList(_context.Genre, "Id", "Genre", mediaCopy.MediaGenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Media Type", mediaCopy.MediaTypeId);
            return View(mediaCopy);
        }

        // GET: MediaCopies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaCopy = await _context.MediaCopy.SingleOrDefaultAsync(m => m.Id == id);
            if (mediaCopy == null)
            {
                return NotFound();
            }
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Title", mediaCopy.MediaId);
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Format", mediaCopy.MediaFormatId);
            ViewData["MediaGenreId"] = new SelectList(_context.Genre, "Id", "Name", mediaCopy.MediaGenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Type", mediaCopy.MediaTypeId);
            return View(mediaCopy);
        }

        // POST: MediaCopies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MediaId,MediaTypeId,MediaGenreId,MediaFormatId,CopyNumber,InActive,InActiveDate")] MediaCopy mediaCopy)
        {
            if (id != mediaCopy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaCopy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaCopyExists(mediaCopy.Id))
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
            ViewData["MediaId"] = new SelectList(_context.Media, "Id", "Author", mediaCopy.MediaId);
            ViewData["MediaFormatId"] = new SelectList(_context.MediaFormat, "Id", "Id", mediaCopy.MediaFormatId);
            ViewData["MediaGenreId"] = new SelectList(_context.Genre, "Id", "Id", mediaCopy.MediaGenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaCopy.MediaTypeId);
            return View(mediaCopy);
        }

        // GET: MediaCopies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaCopy = await _context.MediaCopy
                .Include(m => m.Media)
                .Include(m => m.MediaFormat)
                .Include(m => m.MediaGenre)
                .Include(m => m.MediaType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mediaCopy == null)
            {
                return NotFound();
            }

            return View(mediaCopy);
        }

        // POST: MediaCopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediaCopy = await _context.MediaCopy.SingleOrDefaultAsync(m => m.Id == id);
            _context.MediaCopy.Remove(mediaCopy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaCopyExists(int id)
        {
            return _context.MediaCopy.Any(e => e.Id == id);
        }
    }
}
