namespace S00132671CA2.Migrations
{
    using S00132671CA2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S00132671CA2.Models.MoviesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(S00132671CA2.Models.MoviesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Movies.AddOrUpdate(mov => mov.MovieName,
                new Movie
                {
                    MovieId = 1,
                    ScreenShot = "http://imageserver.moviepilot.com/dark-knight-wide-just-how-different-was-nolan-s-third-batman-movie-supposed-to-be.jpeg?width=3650&height=1554",
                    PosterURL = "http://img.auctiva.com/imgdata/1/1/7/9/1/0/1/webimg/592135647_o.jpg", MovieName = "The Dark Knight",
                    Description = "The follow-up to Batman Begins, The Dark Knight reunites director Christopher Nolan and star Christian Bale, who reprises the role of Batman/Bruce Wayne in his continuing war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to destroy organized crime in Gotham for good. The triumvirate proves effective. But soon the three find themselves prey to a rising criminal mastermind known as The Joker, who thrusts Gotham into anarchy and forces Batman closer to crossing the fine line between hero and vigilante."
                },
                new Movie { MovieId = 10, ScreenShot = "http://1.bp.blogspot.com/-STey1n3vFeA/UOlEuyzj_hI/AAAAAAAADSU/A0mSwOeJE50/s1600/3.jpg", PosterURL = "http://images.moviepostershop.com/oldboy-movie-poster-2003-1020263711.jpg", MovieName = "OldBoy", Description = "An average man is kidnapped and imprisoned in a shabby cell for 15 years without explanation. He then is released, equipped with money, a cellphone and expensive clothes. As he strives to explain his imprisonment and get his revenge, Oh Dae-Su soon finds out that his kidnapper has a greater plan for him and is set onto a path of pain and suffering in an attempt to uncover the motive of his mysterious tormentor." },
                new Movie { MovieId = 3, ScreenShot = "http://pivotallabs.com/wordpress/wp-content/uploads/2013/07/Inception.jpg", PosterURL = "http://www.thinkhero.com/wp-content/uploads/2010/04/zz29f736b0.jpg", MovieName = "Inception", Description = "Dom Cobb is a skilled thief, the absolute best in the dangerous art of extraction, stealing valuable secrets from deep within the subconscious during the dream state, when the mind is at its most vulnerable. Cobb's rare ability has made him a coveted player in this treacherous new world of corporate espionage, but it has also made him an international fugitive and cost him everything he has ever loved. Now Cobb is being offered a chance at redemption. One last job could give him his life back but only if he can accomplish the impossible-inception. Instead of the perfect heist, Cobb and his team of specialists have to pull off the reverse: their task is not to steal an idea but to plant one. If they succeed, it could be the perfect crime. But no amount of careful planning or expertise can prepare the team for the dangerous enemy that seems to predict their every move. An enemy that only Cobb could have seen coming." },
                new Movie { MovieId = 4, ScreenShot="http://i.kinja-img.com/gawker-media/image/upload/s--TiYojV_K--/dvz6jwsdkyksubzhnmsq.jpg", PosterURL = "https://www.movieposter.com/posters/archive/main/98/MPW-49351", MovieName = "Toy Story 3", Description = "Andy is now 17 and ready to head off to college, leaving Woody, Buzz, Jessie, and the rest of the toy-box gang to ponder their uncertain futures. When the toys are accidentally donated to the Sunnyside Daycare center they're initially overjoyed to once again be played with, but their enthusiasm quickly gives way to horror as they discover the true nature of the establishment under the rule of the deceptively welcoming Lotso Bear. Now, all of the toys must band together in one final, crazy scheme to escape their confines and return home to Andy." },
                new Movie { MovieId = 5, ScreenShot="http://i.telegraph.co.uk/multimedia/archive/02859/FROZEN_crop_2859472b.jpg", PosterURL = "http://media-cache-ec0.pinimg.com/236x/04/77/36/047736c9648cbcb3ad3088a674a932c9.jpg", MovieName = "Frozen", Description = "Anna, a fearless optimist, sets off on an epic journey - teaming up with rugged mountain man Kristoff and his loyal reindeer Sven - to find her sister Elsa, whose icy powers have trapped the kingdom of Arendelle in eternal winter. Encountering Everest-like conditions, mystical trolls and a hilarious snowman named Olaf, Anna and Kristoff battle the elements in a race to save the kingdom. From the outside Anna's sister, Elsa looks poised, regal and reserved, but in reality, she lives in fear as she wrestles with a mighty secret-she was born with the power to create ice and snow. It's a beautiful ability, but also extremely dangerous. Haunted by the moment her magic nearly killed her younger sister Anna, Elsa has isolated herself, spending every waking minute trying to suppress her growing powers. Her mounting emotions trigger the magic, accidentally setting off an eternal winter that she can't stop. She fears she's becoming a monster and that no one, not even her sister, can help her." },
                new Movie { MovieId = 6,  ScreenShot="http://3.bp.blogspot.com/-ddqxObTwebU/TcGNQ1YWG5I/AAAAAAAAB4s/oKG0POYX3DI/s1600/snatch1.jpg",
                    PosterURL = "http://www.gadgetreview.com/wp-content/uploads/2012/11/snatch-movie-poster-500w.jpg", MovieName = "Snatch", Description = "Turkish and his close friend/accomplice Tommy get pulled into the world of match fixing by the notorious Brick Top. Things get complicated when the boxer they had lined up gets badly beaten by Pitt, a 'pikey' ( slang for an Irish Gypsy)- who comes into the equation after Turkish, an unlicensed boxing promoter wants to buy a caravan off the Irish Gypsies. They then try to convince Pitt not only to fight for them, but to lose for them too. Whilst all this is going on, a huge diamond heist takes place, and a fistful of motley characters enter the story, including 'Cousin Avi', 'Boris The Blade', 'Franky Four Fingers' and 'Bullet Tooth Tony'. Things go from bad to worse as it all becomes about the money, the guns, and the damned dog!" },
                new Movie { MovieId = 7, ScreenShot = "http://news.bbcimg.co.uk/media/images/67865000/jpg/_67865364_rexfeatures_1603050a.jpg", PosterURL = "https://www.movieposter.com/posters/archive/main/90/MPW-45270", MovieName = "Rocky", Description = "Rocky Balboa is a struggling boxer trying to make the big time, working as a debt collector for a pittance. When heavyweight champion Apollo Creed visits Philadelphia, his managers want to set up an exhibition match between Creed and a struggling boxer, touting the fight as a chance for a nobody to become a somebody. The match is supposed to be easily won by Creed, but someone forgot to tell Rocky, who sees this as his only shot at the big time." },
                new Movie { MovieId = 8, ScreenShot = "http://cdn.screenrant.com/wp-content/uploads/scarface-remake-director.jpg", PosterURL = "https://www.movieposter.com/posters/archive/main/117/MPW-58950", MovieName = "Scarface", Description = "Tony Montana manages to leave Cuba during the Mariel exodus of 1980. He finds himself in a Florida refugee camp but his friend Manny has a way out for them: undertake a contract killing and arrangements will be made to get a green card. He's soon working for drug dealer Frank Lopez and shows his mettle when a deal with Columbian drug dealers goes bad. He also brings a new level of violence to Miami. Tony is protective of his younger sister but his mother knows what he does for a living and disowns him. Tony is impatient and wants it all however, including Frank's empire and his mistress Elvira Hancock. Once at the top however, Tony's outrageous actions make him a target and everything comes crumbling down.  Movie" },
                new Movie { MovieId = 9, ScreenShot = "http://imageserver.moviepilot.com/die-hard-original-best-in-the-series.jpeg?width=1281&height=720", PosterURL = "http://schmoesknow.com/wp-content/uploads/2014/03/die-hard-movie-poster-1988.jpg", MovieName = "Die Hard", Description = "New York City Detective John McClane has just arrived in Los Angeles to spend Christmas with his wife. Unfortunatly, it is not going to be a Merry Christmas for everyone. A group of terrorists, led by Hans Gruber is holding everyone in the Nakatomi Plaza building hostage. With no way of anyone getting in or out, it's up to McClane to stop them all. All 12!" },
                         new Movie { MovieId = 2, ScreenShot = "http://imageserver.moviepilot.com/6a00d8341bfb1653ef01a511ba63de970c-christopher-nolan-s-interstellar-scientific-vision-makes-revolutionary-movie.jpeg?width=2880&height=1800", PosterURL = "http://www.hollywoodreporter.com/sites/default/files/custom/Blog_Images/interstellar3.jpg", MovieName = "Interstellar", Description = "In the near future, Earth has been devastated by drought and famine, causing a scarcity in food and extreme changes in climate. When humanity is facing extinction, a mysterious rip in the space-time continuum is discovered, giving mankind the opportunity to widen its lifespan. A group of explorers must travel beyond our solar system in search of a planet that can sustain life. The crew of the Endurance are required to think bigger and go further than any human in history as they embark on an interstellar voyage into the unknown. Coop, the pilot of the Endurance, must decide between seeing his children again and the future of the human race." });

            context.Actors.AddOrUpdate(act => act.ActorName,
                new Actor() { ActorName = "Christian Bale", ActorId = 1 },
                  new Actor() { ActorName = "Tom Hardy", ActorId = 2 },
                    new Actor() { ActorName = "Michael Caine", ActorId = 3 });

            context.Cast.AddOrUpdate(ca => ca.CastName,
                new CastList() { MovieId = 1, ActorId = 1, CastName = "Bruce Wayne" },
                 new CastList() { MovieId = 1, ActorId = 2, CastName = "Bane" },
                   new CastList() { MovieId = 1, ActorId = 3, CastName = "Alfred" },
                     new CastList() { MovieId = 2, ActorId = 3, CastName = "Some Guy" });
        }
    }
}
