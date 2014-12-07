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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        MoviesContext db = new MoviesContext();


        //autcomplete method for search
        public ActionResult Autocomplete(string term)
        {
            var model =
              db.Movies.Where(mov => mov.MovieName.StartsWith(term))
              .Take(5)
              .Select(movie => new
              {
                  label = movie.MovieName
              });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string message, string movieName, int page = 1, string searchTerm = null)
        {

            if (!string.IsNullOrEmpty(message)) { ViewBag.message = message; }

            if (!string.IsNullOrEmpty(movieName)) { ViewBag.MovieName = movieName; }
            
            //get all movies 
            var movies = from mo in db.Movies
                          orderby mo.MovieName ascending
                          where searchTerm == null || mo.MovieName.Contains(searchTerm)
                          select mo;


            if(Request.IsAjaxRequest())
            {
                return PartialView("_Movies", movies.ToPagedList(page,10));
            }

            return View(movies.ToPagedList(page, 10));
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {ViewBag.message = message;  }

            var movies = db.Movies.Find(id);

            //if no movies return to index
            if (movies == null)
                return RedirectToAction("Index", new { message = "Warning" });

            return View(movies);
        }
   


        //partial create view for modal
        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("_Create");
        }

        public PartialViewResult ShowActorMovies(int id)
        {
            return PartialView("_ActorMovies", db.Actors.Find(id));
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    //return to index with message for toast notification

                    return RedirectToAction("Index", new { message = "Success", movieName = movie.MovieName });
                }
                else
                {
                    return View(movie);
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        [HttpGet]
        public PartialViewResult Edit(int id)
        {


            return PartialView("_Edit", db.Movies.Find(id));
        }
        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie editMovie)
        {
            try
            {

                db.Entry(editMovie).State = EntityState.Modified;
                db.SaveChanges();
                //return to the movie you've just edited
                return RedirectToAction("Details", new { id = editMovie.MovieId });
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Home/Delete/5

        public PartialViewResult Delete(int id)
        {
            return PartialView("_Delete", db.Movies.Find(id));
        }
        // POST: /Home/Delete/5

      
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfimDelete(int id)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Remove(db.Movies.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Gone" });
            }
            else
                return View();
        }
    }
}
