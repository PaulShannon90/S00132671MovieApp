using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S00132671CA2.Models;

namespace S00132671CA2.Controllers
{
    public class ActorController : Controller
    {
        //
        // GET: /Actor/
        MoviesContext db = new MoviesContext();

        public ActionResult Index()
        {
            var actors = db.Actors.ToList();

            return View(actors);
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
