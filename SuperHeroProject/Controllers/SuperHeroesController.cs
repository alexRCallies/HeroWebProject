using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Data;
using SuperHeroProject.Models;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroesController : Controller
    {
        readonly ApplicationDbContext dbContext;
            // GET: SuperHeroes
            public SuperHeroesController(ApplicationDbContext db)
        {
            this.dbContext = db;
        }
        public ActionResult Index()
        {
            return View(dbContext.superHeroes.ToList());
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            var hero = dbContext.superHeroes.Where(x => x.ID == id).FirstOrDefault();
            return View(hero);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View(superHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                dbContext.superHeroes.Add(superHero);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
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

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superHero = new SuperHero();
            return View();
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here

                dbContext.superHeroes.Remove(superHero);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}