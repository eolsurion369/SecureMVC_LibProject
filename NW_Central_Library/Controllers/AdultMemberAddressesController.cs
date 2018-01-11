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
    public class AdultMemberAddressesController : Controller
    {
        private readonly LibProjectContext _context;

        public AdultMemberAddressesController(LibProjectContext context)
        {
            _context = context;
        }

        // GET: AdultMemberAddresses
        public async Task<IActionResult> Index()
        {
            var libProjectContext = _context.AdultMemberAddress.Include(a => a.Address).Include(a => a.Adult);
            return View(await libProjectContext.ToListAsync());
        }

        // GET: AdultMemberAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adultMemberAddress = await _context.AdultMemberAddress
                .Include(a => a.Address)
                .Include(a => a.Adult)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (adultMemberAddress == null)
            {
                return NotFound();
            }

            return View(adultMemberAddress);
        }

        // GET: AdultMemberAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Address Line 1");
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "First Name");
            return View();
        }

        // POST: AdultMemberAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdultId,AddressId,InActive,InActiveDate")] AdultMemberAddress adultMemberAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adultMemberAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "AddrLn1", adultMemberAddress.AddressId);
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", adultMemberAddress.AdultId);
            return View(adultMemberAddress);
        }

        // GET: AdultMemberAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adultMemberAddress = await _context.AdultMemberAddress.SingleOrDefaultAsync(m => m.AdultId == id);
            if (adultMemberAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Address Line 1", adultMemberAddress.AddressId);
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "First Name", adultMemberAddress.AdultId);
            return View(adultMemberAddress);
        }

        // POST: AdultMemberAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdultId,AddressId,InActive,InActiveDate")] AdultMemberAddress adultMemberAddress)
        {
            if (id != adultMemberAddress.AdultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adultMemberAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdultMemberAddressExists(adultMemberAddress.AdultId))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "AddrLn1", adultMemberAddress.AddressId);
            ViewData["AdultId"] = new SelectList(_context.AdultMember, "Id", "FirstName", adultMemberAddress.AdultId);
            return View(adultMemberAddress);
        }

        // GET: AdultMemberAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adultMemberAddress = await _context.AdultMemberAddress
                .Include(a => a.Address)
                .Include(a => a.Adult)
                .SingleOrDefaultAsync(m => m.AdultId == id);
            if (adultMemberAddress == null)
            {
                return NotFound();
            }

            return View(adultMemberAddress);
        }

        // POST: AdultMemberAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adultMemberAddress = await _context.AdultMemberAddress.SingleOrDefaultAsync(m => m.AdultId == id);
            _context.AdultMemberAddress.Remove(adultMemberAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdultMemberAddressExists(int id)
        {
            return _context.AdultMemberAddress.Any(e => e.AdultId == id);
        }
    }
}
