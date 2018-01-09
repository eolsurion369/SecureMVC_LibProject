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
    public class Media1Controller : Controller
    {
        private readonly LibProjectContext _context;

        public Media1Controller(LibProjectContext context)
        {
            _context = context;
        }

        // GET: Media1
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.Media.Include(m => m.Publisher).Include(m => m.Series);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: Media1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .Include(m => m.Publisher)
                .Include(m => m.Series)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        [Authorize]
        // GET: Media1/Create
        public IActionResult Create()
        {
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Name");
            return View();
        }

        // POST: Media1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,SeriesId,Author,PublisherId,CopyRightDate,Characteristics,Summary,InActive,InActiveDate")] Media media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name", media.PublisherId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Name", media.SeriesId);
            return View(media);
        }

        // GET: Media1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media.SingleOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name", media.PublisherId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Name", media.SeriesId);
            return View(media);
        }

        // POST: Media1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,SeriesId,Author,PublisherId,CopyRightDate,Characteristics,Summary,InActive,InActiveDate")] Media media)
        {
            if (id != media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.Id))
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
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name", media.PublisherId);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Name", media.SeriesId);
            return View(media);
        }

        // GET: Media1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .Include(m => m.Publisher)
                .Include(m => m.Series)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Media.SingleOrDefaultAsync(m => m.Id == id);
            _context.Media.Remove(media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Media.Any(e => e.Id == id);
        }
    }
}
