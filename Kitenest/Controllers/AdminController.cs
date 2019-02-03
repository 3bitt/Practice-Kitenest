using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitenest.Data;
using Kitenest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kitenest.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private readonly KitenestDbContext _context;
        //private readonly UserManager<IdentityUser> manager;

        public AdminController(KitenestDbContext context)
        {
            _context = context;
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult manageSchools()
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


        [HttpGet]
        public ActionResult manageUsers()
        {           
            
            // Lista ról
            var rolelistDB = _context.Roles;
            var rolelistSort = (from r in rolelistDB
                                orderby r.Name
                                select r);
            var roles = rolelistSort.ToList().Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name }).ToList();
            ViewBag.Roles = roles;

            // Lista użytkowników
            var userlistDB = _context.Users;
            var userlistSort = (from u in userlistDB
                                orderby u.UserName
                                select u);
            var users = userlistSort.ToList().Select(u => new SelectListItem { Value = u.UserName.ToString(), Text = u.UserName }).ToList();
            ViewBag.Users = users;

            ViewBag.Message = "";

            return View();
            
        }

        [HttpGet]
        public ActionResult createRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createRole(FormCollection collection)
        {
            try
            {
                _context.Roles.Add(new IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                _context.SaveChanges();
                ViewBag.Message = "Pomyślnie utworzono rolę !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}