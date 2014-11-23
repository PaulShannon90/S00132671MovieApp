using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S00132671CA2.Models;

namespace S00132671CA2.Controllers
{
    public class CastController : Controller
    {
        private MoviesContext db = new MoviesContext();

        //
        // GET: /Cast/


        public ActionResult Index()
        {
            var cast = db.Cast.Include(c => c.Movie).Include(c => c.Actor);
            return View(cast.ToList());
        }

        //
        // GET: /Cast/Details/5

        public ActionResult Details(int? MovieId, int? ActorId)
        {
            CastList castlist = db.Cast.Find(MovieId, ActorId);
            if (castlist == null)
            {
                return HttpNotFound();
            }
            return View(castlist);
        }

        //
        // GET: /Cast/Create

        public ActionResult Create()
        {
            CastList castlist = new CastList();
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);
           
            return View();
        }

        //
        // POST: /Cast/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CastList castlist)
        {
            if (ModelState.IsValid)
            {
                db.Cast.Add(castlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);
            return View(castlist);
        }

        //
        // GET: /Cast/Edit/5

        public ActionResult Edit(int? MovieId, int? ActorId)
        {
            CastList castlist = db.Cast.Find(MovieId, ActorId);
            if (castlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);
            return View(castlist);
        }

        //
        // POST: /Cast/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CastList castlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);
            return View(castlist);
        }

        //
        // GET: /Cast/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CastList castlist = db.Cast.Find(id);
            if (castlist == null)
            {
                return HttpNotFound();
            }
            return View(castlist);
        }

        //
        // POST: /Cast/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastList castlist = db.Cast.Find(id);
            db.Cast.Remove(castlist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}