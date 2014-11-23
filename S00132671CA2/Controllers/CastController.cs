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
        // GET: /Cast/Create

        [HttpGet]
        public PartialViewResult Create()
        {
            CastList castlist = new CastList();
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);

            return PartialView("_Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CastList castlist)
        {
            if (ModelState.IsValid)
            {
                var login = from d in db.Cast
                            where d.ActorId == castlist.ActorId
                            && d.MovieId == castlist.MovieId
                            select d;

                if (login.Any())
                {
                    return RedirectToAction("Details", "Home", new { id = castlist.MovieId, message = "DataError" });
                }

                db.Cast.Add(castlist);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = castlist.MovieId });
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);
            return View(castlist);
        }

        //
        // GET: /Cast/Edit/5
        [HttpGet]
        public PartialViewResult Edit(int? MovieId, int? ActorId)
        {

            CastList castlist = db.Cast.Find(MovieId, ActorId);

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);

            return PartialView("_Edit", db.Cast.Find(MovieId, ActorId));
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
                return RedirectToAction("Details", "Home", new { id = castlist.MovieId });
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "MovieName", castlist.MovieId);
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "ActorName", castlist.ActorId);
            return View(castlist);
        }

        //
        // GET: /Cast/Delete/5
        public PartialViewResult Delete(int? MovieId, int? ActorId)
        {
            return PartialView("_Delete", db.Cast.Find(MovieId, ActorId));
        }

        // POST: /Cast/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? MovieId, int? ActorId)
        {
            if (ModelState.IsValid)
            {
                CastList castlist = db.Cast.Find(MovieId, ActorId);
                db.Cast.Remove(castlist);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = MovieId });
            }
            else return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}