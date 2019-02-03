using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kitenest.Data;
using Kitenest.Models;
using Kitenest.Models.Interfaces;
using System.Collections.Generic;
using Kitenest.Validators;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Microsoft.AspNetCore.Authorization;
using Kitenest.ViewModels;

namespace Kitenest.Controllers
{
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class SchoolsController : Controller
    {
        public int pageSize = 10;
        private readonly KitenestDbContext _context;

        public SchoolsController(KitenestDbContext context)
        {
            _context = context;
        }


        // GET: Schools
        public async Task<IActionResult> Index()
        {
            var kitenestDbContext = _context.School.Include(s => s.City).Include(s => s.Continent);
            return View(await kitenestDbContext.ToListAsync());
        }

        // GET: Schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School
                .Include(s => s.City)
                .Include(s => s.Continent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: Schools/Create

        public IActionResult Create()
        {
            ViewBag.Continents = new SelectList(_context.Continent.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_context.City.ToList(), "Id", "Name");

            return View();
        }

        // POST: Schools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create([Bind("Id,Name,Mobile,Continent_id,Country,City_id")] School school)
        {               
            
            if (ModelState.IsValid )
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction("manageSchools", "Admin");
            }

            ViewBag.Continents = new SelectList(_context.Continent.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_context.City.ToList(), "Id", "Name");
            return View();
        }

        // GET: Schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            
            ViewBag.Continents = new SelectList(_context.Continent.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_context.City.ToList(), "Id", "Name");
            
            return View(school);
        }

        // POST: Schools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mobile,Continent_id,Country,City_id")] School school)
        {
            if (id != school.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.Id))
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

            ViewBag.Continents = new SelectList(_context.Continent.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_context.City.ToList(), "Id", "Name");
            return View(school);
        }

        // GET: Schools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School
                .Include(s => s.City)
                .Include(s => s.Continent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var school = await _context.School.FindAsync(id);
            _context.School.Remove(school);
            await _context.SaveChangesAsync();
            return RedirectToAction("manageSchools", "Admin");
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }


        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous] 
        [Route("Search")]
        public async Task<IActionResult> SearchSchools(string schoolName, string continent, string country,
            string city, [FromQuery]int page = 1)
        {

            SchoolsViewModel schoolsList = new SchoolsViewModel();

            var query = _context.School
                .Include(e => e.City)
                .Include(e => e.Continent);

            var resultQuery = query.Where(e =>
                ((string.IsNullOrEmpty(schoolName) ? e.Id > 0 : e.Name.Contains(schoolName)) &&
                (string.IsNullOrEmpty(continent) ? e.Id > 0 : e.Continent.Name.Contains(continent)) &&
                (string.IsNullOrEmpty(city) ? e.Id > 0 : e.City.Name.Contains(city)) &&
                (string.IsNullOrEmpty(country) ? e.Id > 0 : e.Country.Contains(country))) )
                .ToList();

            var limitedResult = resultQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize);



            schoolsList.Schools = limitedResult;
            schoolsList.CurrentPage = page;
            schoolsList.TotalPages = (resultQuery.Count() / pageSize);

            return View(schoolsList);
      
        }
    }
}
