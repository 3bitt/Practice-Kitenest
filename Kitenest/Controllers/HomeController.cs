using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kitenest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kitenest.Data;
using Kitenest.ViewModels;

namespace Kitenest.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly KitenestDbContext _context;
        //private readonly UserManager<IdentityUser> manager;

        public HomeController(KitenestDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("main")]
        public IActionResult Search()
        {
            return View();
        }


        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            var continents = _context.Continent;
            var countries = _context.Country;
            var cities = _context.City;
            var schools = _context.School
                .Include(s => s.City)
                .Include(s => s.Continent);

            WorldViewModel result = new WorldViewModel();
            result.Continents = continents;
            result.Countries = countries;
            result.Cities = cities;
            result.Schools = schools;

            return View(result);
            
        }
        
    }
}
