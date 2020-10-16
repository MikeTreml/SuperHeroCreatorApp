using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroCreator.Data;
using SuperHeroCreator.Models;

namespace SuperHeroCreator.Controllers
{
    public class SuperHeroes : Controller
    {

        private readonly ApplicationDbContext _db;
        public SuperHeroes(ApplicationDbContext db)
        {
            _db = db;
        }


        // GET: SuperHeroes
        public ActionResult Index()
        {
            var superHeroes = _db.SuperHeroes;
            return View(superHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            var superHeroes = _db.SuperHeroes.Where(a => a.Id == id).FirstOrDefault();
            return View(superHeroes);
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
                _db.SuperHeroes.Add(superHero);
                _db.SaveChanges();
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
            var editHero = _db.SuperHeroes.Where(h => h.Id == id);
            return View();
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superhero)
        {
            try
            {
                _db.SuperHeroes.Update(superhero);
                _db.SaveChanges();
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
            var superHero = _db.SuperHeroes.Where(h => h.Id == id);
            return View(superHero);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                _db.SuperHeroes.Remove(superHero);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
