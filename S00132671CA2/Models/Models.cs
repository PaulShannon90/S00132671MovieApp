using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S00132671CA2.Models
{
    public class Movie
    {
        Random rand = new Random();

        [Required]
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get;set; }
        private string _poster;
         [Display(Name = "Movie Poster URL")]
         [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Please enter a valid URL")]
        public string PosterURL
        {
            
                 get
             { return _poster; }
             set
             {
                 if(string.IsNullOrEmpty(value))
             {
                 _poster = "http://www.images.act.gov.au/duslibrary/imagesact.nsf/no_image.gif";
             }
             else
                 _poster = value;

             }
            
        }
         private string _screenshot;
         [Display(Name = "Screen Shot URL")]
         [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Please enter a valid image url")]
         public string ScreenShot
         {
             get
             { return _screenshot; }
             set
             { if(string.IsNullOrEmpty(value))
             {
                 _screenshot = "http://bgfons.com/upload/iron_texture47.jpg";
             }
             else
                 _screenshot = value;

             }
         }
        public string Description { get; set; }
      
        public virtual List<CastList> Actors { get; set; }
    }

    public class Actor
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        [Display(Name = "Actor Name")]
        public string ActorName { get; set; }
        public virtual List<CastList> Movies { get; set; }
        
    }

    public class CastList
    {
         [Key, Column(Order = 0)]
        public int MovieId { get; set; }
         public virtual Movie Movie { get; set; }
          [Key, Column(Order = 1)]
        public int ActorId { get; set; }
          public virtual Actor Actor { get; set; }
          public string CastName { get; set; }

    }

    public class MoviesContext: DbContext
    {
        public MoviesContext(): base("name=MoviesContext")
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<CastList> Cast { get; set; }
    }

    public class CastViewModel
    {
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
        public IEnumerable<SelectListItem> MovieNames { get; set; }
    }

   
}