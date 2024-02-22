using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RentalsController : Controller
    {
        private readonly RentalDbContext _context;

        public RentalsController(RentalDbContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var rentalDbContext = _context.Rentals.Include(r => r.Cars).Include(r => r.Customer);
            return View(await rentalDbContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals
                .Include(r => r.Cars)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
            ViewData["CustId"] = new SelectList(_context.Customer, "Id", "Id");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustId,CarId,RentDate,ReceiveDate,StartMeterReading,EndMeterReading")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", rentals.CarId);
            ViewData["CustId"] = new SelectList(_context.Customer, "Id", "Id", rentals.CustId);
            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals.FindAsync(id);
            if (rentals == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", rentals.CarId);
            ViewData["CustId"] = new SelectList(_context.Customer, "Id", "Id", rentals.CustId);
            return View(rentals);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustId,CarId,RentDate,ReceiveDate,StartMeterReading,EndMeterReading")] Rentals rentals)
        {
            if (id != rentals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalsExists(rentals.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", rentals.CarId);
            ViewData["CustId"] = new SelectList(_context.Customer, "Id", "Id", rentals.CustId);
            return View(rentals);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals
                .Include(r => r.Cars)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentals == null)
            {
                return NotFound();
            }

            return View(rentals);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rentals == null)
            {
                return Problem("Entity set 'RentalDbContext.Rentals'  is null.");
            }
            var rentals = await _context.Rentals.FindAsync(id);
            if (rentals != null)
            {
                _context.Rentals.Remove(rentals);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalsExists(int id)
        {
          return _context.Rentals.Any(e => e.Id == id);
        }
    }
}
