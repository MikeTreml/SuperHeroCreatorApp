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
            var superHero = _db.SuperHeroes.Where(h => h.Id == id).SingleOrDefault();
            return View(superHero);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                _db.SuperHeroes.Update(superHero);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(superHero);
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            var superHero = _db.SuperHeroes.Where(h => h.Id == id).SingleOrDefault();
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

        public ActionResult AddRecords() 
        {
            SuperHero hero = new SuperHero();

            hero.Name = "DeadPool";
            hero.AlterEgo = "Wade Winston Wilson";
            hero.PrimaryAbility = "Regenerative healing factor";
            hero.SecondaryAbility = "Extended longevity";
            hero.CatchPhrase = "I want to die a natural death at the age of 102 - like the city of Detroit.";
            hero.Picture = "images/deadpool.jpg";
            Create(hero);
            
            hero.Id = 0;
            hero.Name = "Spider-Man";
            hero.AlterEgo = "Peter Benjamin Parker";
            hero.PrimaryAbility = "Genius intellect";
            hero.SecondaryAbility = "Precognitive spider-sense ability";
            hero.CatchPhrase = "With great power, there must also come great responsibility.";
            hero.Picture = "images/spiderman.jpg";
            Create(hero);

            hero.Id = 0;
            hero.Name = "The Tick";
            hero.AlterEgo = "I.P. Daley / Mr. Nedd";
            hero.PrimaryAbility = "Superhuman strength";
            hero.SecondaryAbility = "Nigh-invulnerability";
            hero.CatchPhrase = "Wicked Men! Cease your antics, or I may be forced to assault you with the U.S. Postal System!";
            hero.Picture = "images/tick.png";
            Create(hero);

            hero.Id = 0;
            hero.Name = "Wolverine";
            hero.AlterEgo = "James 'Logan' Howlett";
            hero.PrimaryAbility = "Regeneration and slowed aging";
            hero.SecondaryAbility = "Indestructible bones via adamantium-infused skeleton";
            hero.CatchPhrase = "I’m the best there is at what I do, and what I do isn’t very nice";
            hero.Picture = "images/wolvreine.jpg";
            Create(hero);

            hero.Id = 0;
            hero.Name = "Groot";
            hero.AlterEgo = "Groot";
            hero.PrimaryAbility = "Accelerated healing factor";
            hero.SecondaryAbility = "Plant manipulation";
            hero.CatchPhrase = "Groot";
            hero.Picture = "images/groot.png";
            Create(hero);

            hero.Id = 0;
            hero.Name = "SuperMan";
            hero.AlterEgo = "Clark Joseph Kent";
            hero.PrimaryAbility = "Strength";
            hero.SecondaryAbility = "Speed";
            hero.CatchPhrase = "Up up nd away";
            hero.Picture = "images/superman.jpg";
            Create(hero);

            hero.Id = 0;
            hero.Name = "Thor";
            hero.AlterEgo = "Thor Odinson";
            hero.PrimaryAbility = "Strength";
            hero.SecondaryAbility = "Speed";
            hero.CatchPhrase = "Odin's beard!";
            hero.Picture = "images/thor.jpg";
            Create(hero);

            hero.Id = 0;
            hero.Name = "Gambit";
            hero.AlterEgo = "Remy Etienne LeBeau";
            hero.PrimaryAbility = "Kinetic energy generation";
            hero.SecondaryAbility = "Superhuman charm";
            hero.CatchPhrase = "Be a bad dog, you get the stick.";
            hero.Picture = "images/gambit.jpg";
            Create(hero);

            return View();
        }
    }
}
