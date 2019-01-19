using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kitenest.Data;
using Kitenest.Models;

namespace Kitenest.Controllers
{
    public class ContinentsController : Controller
    {
        private readonly KitenestDbContext _context;

        public ContinentsController(KitenestDbContext context)
        {
            _context = context;
        }

        // GET: Continents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Continent.ToListAsync());
        }

        // GET: Continents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continent = await _context.Continent
                .FirstOrDefaultAsync(m => m.id == id);
            if (continent == null)
            {
                return NotFound();
            }

            return View(continent);
        }

        // GET: Continents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Continents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Continent continent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(continent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Admin", "Home");
            }
            return View(continent);
        }

        // GET: Continents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continent = await _context.Continent.FindAsync(id);
            if (continent == null)
            {
                return NotFound();
            }
            return View(continent);
        }

        // POST: Continents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Continent continent)
        {
            if (id != continent.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(continent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContinentExists(continent.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Admin", "Home");
            }
            return View(continent);
        }

        // GET: Continents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var continent = await _context.Continent
                .FirstOrDefaultAsync(m => m.id == id);
            if (continent == null)
            {
                return NotFound();
            }

            return View(continent);
        }

        // POST: Continents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var continent = await _context.Continent.FindAsync(id);
            _context.Continent.Remove(continent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Admin", "Home");
        }

        private bool ContinentExists(int id)
        {
            return _context.Continent.Any(e => e.id == id);
        }

        
        public async Task<ActionResult> getContinents()
        {
            var continents = _context.Continent.ToList();

            return PartialView(continents);
        }
    }
}
