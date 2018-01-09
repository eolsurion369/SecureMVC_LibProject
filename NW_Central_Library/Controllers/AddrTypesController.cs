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
    public class AddrTypesController : Controller
    {
        private readonly LibProjectContext _context;

        public AddrTypesController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: AddrTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddrType.ToListAsync());
        }

        // GET: AddrTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addrType = await _context.AddrType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addrType == null)
            {
                return NotFound();
            }

            return View(addrType);
        }

        // GET: AddrTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddrTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,InActive,InActiveDate")] AddrType addrType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addrType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addrType);
        }

        // GET: AddrTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addrType = await _context.AddrType.SingleOrDefaultAsync(m => m.Id == id);
            if (addrType == null)
            {
                return NotFound();
            }
            return View(addrType);
        }

        // POST: AddrTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Type,InActive,InActiveDate")] AddrType addrType)
        {
            if (id != addrType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addrType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddrTypeExists(addrType.Id))
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
            return View(addrType);
        }

        // GET: AddrTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addrType = await _context.AddrType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addrType == null)
            {
                return NotFound();
            }

            return View(addrType);
        }

        // POST: AddrTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var addrType = await _context.AddrType.SingleOrDefaultAsync(m => m.Id == id);
            _context.AddrType.Remove(addrType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddrTypeExists(string id)
        {
            return _context.AddrType.Any(e => e.Id == id);
        }
    }
}
