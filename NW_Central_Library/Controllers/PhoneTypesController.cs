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
    public class PhoneTypesController : Controller
    {
        private readonly LibProjectContext _context;

        public PhoneTypesController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: PhoneTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneType.ToListAsync());
        }

        // GET: PhoneTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneType = await _context.PhoneType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phoneType == null)
            {
                return NotFound();
            }

            return View(phoneType);
        }

        [Authorize]
        // GET: PhoneTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,InActive,InActiveDate")] PhoneType phoneType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneType);
        }

        // GET: PhoneTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneType = await _context.PhoneType.SingleOrDefaultAsync(m => m.Id == id);
            if (phoneType == null)
            {
                return NotFound();
            }
            return View(phoneType);
        }

        // POST: PhoneTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Type,InActive,InActiveDate")] PhoneType phoneType)
        {
            if (id != phoneType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneTypeExists(phoneType.Id))
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
            return View(phoneType);
        }

        // GET: PhoneTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneType = await _context.PhoneType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phoneType == null)
            {
                return NotFound();
            }

            return View(phoneType);
        }

        // POST: PhoneTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phoneType = await _context.PhoneType.SingleOrDefaultAsync(m => m.Id == id);
            _context.PhoneType.Remove(phoneType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneTypeExists(string id)
        {
            return _context.PhoneType.Any(e => e.Id == id);
        }
    }
}
