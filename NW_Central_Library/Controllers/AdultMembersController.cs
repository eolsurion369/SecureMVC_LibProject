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
    public class AdultMembersController : Controller
    {
        private readonly LibProjectContext _context;

        public AdultMembersController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: AdultMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdultMember.ToListAsync());
        }

        // GET: AdultMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adultMember = await _context.AdultMember
                .SingleOrDefaultAsync(m => m.Id == id);
            if (adultMember == null)
            {
                return NotFound();
            }

            return View(adultMember);
        }

        [Authorize]
        // GET: AdultMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdultMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,MidInit,Suffix,Birthdate,InActive,InActiveDate")] AdultMember adultMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adultMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adultMember);
        }

        // GET: AdultMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adultMember = await _context.AdultMember.SingleOrDefaultAsync(m => m.Id == id);
            if (adultMember == null)
            {
                return NotFound();
            }
            return View(adultMember);
        }

        // POST: AdultMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,MidInit,Suffix,Birthdate,InActive,InActiveDate")] AdultMember adultMember)
        {
            if (id != adultMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adultMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdultMemberExists(adultMember.Id))
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
            return View(adultMember);
        }

        // GET: AdultMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adultMember = await _context.AdultMember
                .SingleOrDefaultAsync(m => m.Id == id);
            if (adultMember == null)
            {
                return NotFound();
            }

            return View(adultMember);
        }

        // POST: AdultMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adultMember = await _context.AdultMember.SingleOrDefaultAsync(m => m.Id == id);
            _context.AdultMember.Remove(adultMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdultMemberExists(int id)
        {
            return _context.AdultMember.Any(e => e.Id == id);
        }
    }
}
