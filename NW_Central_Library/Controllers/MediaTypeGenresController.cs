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
    public class MediaTypeGenresController : Controller
    {
        private readonly LibProjectContext _context;

        public MediaTypeGenresController(LibProjectContext context)
        {
            _context = context;
        }

    
        // GET: MediaTypeGenres
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.MediaTypeGenre.Include(m => m.Genre).Include(m => m.MediaType);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: MediaTypeGenres/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaTypeGenre = await _context.MediaTypeGenre
                .Include(m => m.Genre)
                .Include(m => m.MediaType)
                .SingleOrDefaultAsync(m => m.MediaTypeId == id);
            if (mediaTypeGenre == null)
            {
                return NotFound();
            }

            return View(mediaTypeGenre);
        }

        [Authorize]
        // GET: MediaTypeGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id");
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id");
            return View();
        }

        // POST: MediaTypeGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediaTypeId,GenreId")] MediaTypeGenre mediaTypeGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaTypeGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", mediaTypeGenre.GenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaTypeGenre.MediaTypeId);
            return View(mediaTypeGenre);
        }

        // GET: MediaTypeGenres/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaTypeGenre = await _context.MediaTypeGenre.SingleOrDefaultAsync(m => m.MediaTypeId == id);
            if (mediaTypeGenre == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", mediaTypeGenre.GenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaTypeGenre.MediaTypeId);
            return View(mediaTypeGenre);
        }

        // POST: MediaTypeGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MediaTypeId,GenreId")] MediaTypeGenre mediaTypeGenre)
        {
            if (id != mediaTypeGenre.MediaTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaTypeGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaTypeGenreExists(mediaTypeGenre.MediaTypeId))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", mediaTypeGenre.GenreId);
            ViewData["MediaTypeId"] = new SelectList(_context.MediaType, "Id", "Id", mediaTypeGenre.MediaTypeId);
            return View(mediaTypeGenre);
        }

        // GET: MediaTypeGenres/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaTypeGenre = await _context.MediaTypeGenre
                .Include(m => m.Genre)
                .Include(m => m.MediaType)
                .SingleOrDefaultAsync(m => m.MediaTypeId == id);
            if (mediaTypeGenre == null)
            {
                return NotFound();
            }

            return View(mediaTypeGenre);
        }

        // POST: MediaTypeGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mediaTypeGenre = await _context.MediaTypeGenre.SingleOrDefaultAsync(m => m.MediaTypeId == id);
            _context.MediaTypeGenre.Remove(mediaTypeGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaTypeGenreExists(string id)
        {
            return _context.MediaTypeGenre.Any(e => e.MediaTypeId == id);
        }
    }
}
