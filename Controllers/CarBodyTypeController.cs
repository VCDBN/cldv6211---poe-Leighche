﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using THERIDEURENT1.models;

namespace THERIDEURENT1.Controllers
{
    public class CarBodyTypeController : Controller
    {
        private readonly TheRideYouRentContext _context;

        public CarBodyTypeController(TheRideYouRentContext context)
        {
            _context = context;
        }

        // GET: CarBodyType
        public async Task<IActionResult> Index()
        {
              return _context.CarBodyTypes != null ? 
                          View(await _context.CarBodyTypes.ToListAsync()) :
                          Problem("Entity set 'TheRideYouRentContext.CarBodyTypes'  is null.");
        }

        // GET: CarBodyType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarBodyTypes == null)
            {
                return NotFound();
            }

            var carBodyType = await _context.CarBodyTypes
                .FirstOrDefaultAsync(m => m.CarBodyTypeId == id);
            if (carBodyType == null)
            {
                return NotFound();
            }

            return View(carBodyType);
        }

        // GET: CarBodyType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarBodyType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarBodyTypeId,Description")] CarBodyType carBodyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carBodyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carBodyType);
        }

        // GET: CarBodyType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarBodyTypes == null)
            {
                return NotFound();
            }

            var carBodyType = await _context.CarBodyTypes.FindAsync(id);
            if (carBodyType == null)
            {
                return NotFound();
            }
            return View(carBodyType);
        }

        // POST: CarBodyType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarBodyTypeId,Description")] CarBodyType carBodyType)
        {
            if (id != carBodyType.CarBodyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carBodyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBodyTypeExists(carBodyType.CarBodyTypeId))
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
            return View(carBodyType);
        }

        // GET: CarBodyType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarBodyTypes == null)
            {
                return NotFound();
            }

            var carBodyType = await _context.CarBodyTypes
                .FirstOrDefaultAsync(m => m.CarBodyTypeId == id);
            if (carBodyType == null)
            {
                return NotFound();
            }

            return View(carBodyType);
        }

        // POST: CarBodyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarBodyTypes == null)
            {
                return Problem("Entity set 'TheRideYouRentContext.CarBodyTypes'  is null.");
            }
            var carBodyType = await _context.CarBodyTypes.FindAsync(id);
            if (carBodyType != null)
            {
                _context.CarBodyTypes.Remove(carBodyType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarBodyTypeExists(int id)
        {
          return (_context.CarBodyTypes?.Any(e => e.CarBodyTypeId == id)).GetValueOrDefault();
        }
    }
}
