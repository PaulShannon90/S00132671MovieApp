using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S00132671CA2.Models;
using PagedList;
using System.Data;

namespace S00132671CA2.Controllers
{
    public class ActorController : Controller
    {
        //
        // GET: /Actor/


        MoviesContext db = new MoviesContext();


        public ActionResult Autocomplete(string term)
        {
            var model =
              db.Actors.Where(mov => mov.ActorName.StartsWith(term))
              .Take(5)
              .Select(movie => new
              {
                  label = movie.ActorName
              });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string message, int page = 1, string searchTerm = null)
        
        {

            var actors = from mo in db.Actors
                         orderby mo.ActorName descending
                         where searchTerm == null || mo.ActorName.Contains(searchTerm)
                         select mo;

            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.message = message;

            }




            if (Request.IsAjaxRequest())
            {
                return PartialView("_Actors", actors.ToPagedList(page, 6));
            }

            return View(actors.ToPagedList(page, 6));
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.message = message;

            }

            var actors = db.Actors.Find(id);

            if (actors == null)
                return RedirectToAction("Index", new { message = "Warning" });

            return View(actors);
        }

        //
        // GET: /Actor/Create

        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }


        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Actors.Add(actor);
                    db.SaveChanges();

                    return RedirectToAction("Details", "Actor", new { id = actor.ActorId  });
                }
                else
                {
                    return View(actor);
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Actor/Edit/5

        [HttpGet]
        public PartialViewResult Edit(int id)
        {


            return PartialView("_Edit", db.Actors.Find(id));
        }

        //
        // POST: /Actor/Edit/5

        
        [HttpPost]
        public ActionResult Edit(Actor editedActor)
        {
            try
            {

                db.Entry(editedActor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = editedActor.ActorId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Actor/Delete/5
        public PartialViewResult Delete(int id)
        {
            return PartialView("_Delete", db.Actors.Find(id));
        }

        //
        // POST: /Actor/Delete/5

        
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfimDelete(int id)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", new { message = "Gone" });
        }
    }
}
