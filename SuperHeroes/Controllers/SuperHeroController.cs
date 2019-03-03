using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db;

        public SuperHeroController()
        {
            db = new ApplicationDbContext();
        }

        // GET: SuperHero
        public ActionResult Index()
        {
            return View(db.SuperHeroes.OrderBy(o => o.Name).ToList());
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            return View(db.SuperHeroes.Find(id));
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                db.SuperHeroes.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superHero);
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.SuperHeroes.Find(id));
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                SuperHero thisSuperHero = db.SuperHeroes.Find(id);

                // why doesn't this work???
                //foreach (var field in thisSuperHero.GetType().GetFields())
                //foreach (var field in thisSuperHero.GetType().GetFields())
                //{
                //    //string fieldName = field.Name;
                //    //var value = field.GetValue(thisSuperHero);
                //    thisSuperHero.GetType().GetField(field.Name).SetValue(thisSuperHero, superHero.GetType().GetField(field.Name).GetValue(superHero));
                //}

                if (superHero.Name != null && superHero.Name != "") thisSuperHero.Name = superHero.Name;
                if (superHero.AlterEgo != null && superHero.AlterEgo != "") thisSuperHero.AlterEgo = superHero.AlterEgo;
                if (superHero.CatchPhrase != null && superHero.CatchPhrase != "") thisSuperHero.CatchPhrase = superHero.CatchPhrase;
                if (superHero.PrimaryAbility != null && superHero.PrimaryAbility != "") thisSuperHero.PrimaryAbility = superHero.PrimaryAbility;
                if (superHero.SecondaryAbility != null && superHero.SecondaryAbility != "") thisSuperHero.SecondaryAbility = superHero.SecondaryAbility;
                thisSuperHero.Favorite = superHero.Favorite;
                if (superHero.ImageFile != null && superHero.ImageFile != "") thisSuperHero.ImageFile = superHero.ImageFile;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superHero);
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superHero = db.SuperHeroes.Find(id);
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                db.SuperHeroes.Remove(db.SuperHeroes.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superHero);
            }
        }
    }
}
