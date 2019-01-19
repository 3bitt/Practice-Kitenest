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

namespace Kitenest.Controllers
{
    
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
        [Authorize(Roles = "Admin")]
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

        public IActionResult Search()
        {
            return View();

        }

        public IActionResult Admin()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Search(String name) //String Continent, String Country, String City
        //{
         

        //    return View();
        //}
    }
}
