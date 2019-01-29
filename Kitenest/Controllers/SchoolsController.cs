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

namespace Kitenest.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly KitenestDbContext _context;

        public SchoolsController(KitenestDbContext context)
        {
            _context = context;
        }

       // private ISchoolService _school;
        

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
           // ViewBag.Countries = new SelectList(_context.Country.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(_context.City.ToList(), "Id", "Name");

            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mobile,Continent_id,Country,City_id")] School school)
        {

            //var countries = _context.Country.Where(e => e.Name.Equals(school.Country));

            //var cities = _context.City.Where(e => e.Name.Equals(school.City));

            //var country_id = _context.Country
            //    .Where(e => e.Name == school.Country.ToString())
            //    .Select(e => e.Id);

            //var city_id = _context.City
            //    .Where(e => e.Name == school.Country.ToString())
            //    .Select(e => e.Id);            
            
            if (ModelState.IsValid )
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction("Admin", "Home");
            }
            //ViewData["City_id"] = new SelectList(_context.City, "id", "id", school.City_id);
            ViewBag.Continents = new SelectList(_context.Continent.ToList(), "Id", "Name");
            //ViewBag.Countries = new SelectList(_context.Country.ToList(), "Id", "Name");
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> SearchSchools(string schoolName, string continent, string country,
            string city)
        {
            

            var query = _context.School
                .Include(e => e.City)
                .Include(e => e.Continent);

            var resultQuery = query.Where(e =>
                ((string.IsNullOrEmpty(schoolName) ? e.Id > 0 : e.Name.Contains(schoolName)) &&
                (string.IsNullOrEmpty(continent) ? e.Id > 0 : e.Continent.Name.Contains(continent)) &&
                (string.IsNullOrEmpty(city) ? e.Id > 0 : e.City.Name.Contains(city)) &&
                (string.IsNullOrEmpty(country) ? e.Id > 0 : e.Country.Contains(country)))
                ).ToList<School>();            


            return View(resultQuery);
      
        }
    }
}
