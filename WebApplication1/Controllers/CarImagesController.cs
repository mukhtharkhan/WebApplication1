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
    public class CarImagesController : Controller
    {
        private readonly RentalDbContext _context;

        public CarImagesController(RentalDbContext context)
        {
            _context = context;
        }

        // GET: CarImages
        public async Task<IActionResult> Index()
        {
            var rentalDbContext = _context.CarImages.Include(c => c.Cars);
            return View(await rentalDbContext.ToListAsync());
        }

        // GET: CarImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarImages == null)
            {
                return NotFound();
            }

            var carImages = await _context.CarImages
                .Include(c => c.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImages == null)
            {
                return NotFound();
            }

            return View(carImages);
        }

        // GET: CarImages/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarName");
            ViewData["CarName"] = new SelectList(_context.Cars, "CarId", "CarName");
            return View();
        }

        // POST: CarImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,ImageUrl")] CarImages carImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarName", carImages.CarId);
            ViewData["CarName"] = new SelectList(_context.Cars, "CarId", "CarName", carImages.CarId);
            return View(carImages);
        }

        // GET: CarImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarImages == null)
            {
                return NotFound();
            }

            var carImages = await _context.CarImages.FindAsync(id);
            if (carImages == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", carImages.CarId);
            return View(carImages);
        }

        // POST: CarImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,ImageUrl")] CarImages carImages)
        {
            if (id != carImages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarImagesExists(carImages.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", carImages.CarId);
            return View(carImages);
        }

        // GET: CarImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarImages == null)
            {
                return NotFound();
            }

            var carImages = await _context.CarImages
                .Include(c => c.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImages == null)
            {
                return NotFound();
            }

            return View(carImages);
        }

        // POST: CarImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarImages == null)
            {
                return Problem("Entity set 'RentalDbContext.CarImages'  is null.");
            }
            var carImages = await _context.CarImages.FindAsync(id);
            if (carImages != null)
            {
                _context.CarImages.Remove(carImages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarImagesExists(int id)
        {
          return _context.CarImages.Any(e => e.Id == id);
        }
    }
}
