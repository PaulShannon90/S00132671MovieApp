using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S00132671CA2.Models;
using PagedList;

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
                         orderby mo.ActorName ascending
                         where searchTerm == null || mo.ActorName.Contains(searchTerm)
                         select mo;





            if (Request.IsAjaxRequest())
            {
                return PartialView("_Actors", actors.ToPagedList(page, 2));
            }

            return View(actors.ToPagedList(page, 2));
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Actor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Actor/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Actor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Actor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Actor/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
