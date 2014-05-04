namespace SmithJessicaHW5.Migrations
{
    using SmithJessicaHW5.App_Start;
    using SmithJessicaHW5.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<SmithJessicaHW5.Models.ActorDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private void SeedMembership()
        {
            AppInitialize.InitSecurity();

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("Jessica", false) == null)
            {
                membership.CreateUserAndAccount("Jessica", "123456");
            }

            if (!roles.GetRolesForUser("Jessica").Contains("Admin"))
            {
                roles.AddUsersToRoles(
                    new[] { "Jessica" }, new[] { "Admin" }
                );
            }
        }

        protected override void Seed(SmithJessicaHW5.Models.ActorDb context)
        {
            context.Movies.AddOrUpdate(
                m => m.Id,
                new Movie
                {
                    Id = 1,
                    Title = "Iron Man",
                    Year = 2008,
                    LengthInMinutes = 126,
                    Format = "Dvd",
                    Genre = "Action",
                    Rating = 5,
                    IsFavorited = true,
                    Actors = new List<Actor> {
                                new Actor {Id = 1, FirstName = "Robert", MiddleInitial ="Z", LastName = "Downey Jr" }
                            }
                },
                new Movie
                {
                    Id = 2,
                    Title = "Catching Fire",
                    Year = 2013,
                    LengthInMinutes = 146,
                    Format = "Dvd",
                    Genre = "Action",
                    Rating = 5,
                    IsFavorited = true,
                    Actors = new List<Actor>{
                                new Actor {Id = 2, FirstName = "Jennifer", MiddleInitial ="R",  LastName = "Lawarence"},
                                new Actor {Id = 3, FirstName = "Josh", MiddleInitial ="W", LastName = "Hutcherson"},
                            }
                },

                new Movie
                {
                    Id = 3,
                    Title = "The Avengers",
                    Year = 2012,
                    LengthInMinutes = 143,
                    Format = "Dvd",
                    Genre = "Action",
                    Rating = 5,
                    IsFavorited = true,
                    Actors = new List<Actor>{
                            new Actor {Id = 4, FirstName = "Hugh", MiddleInitial ="M", LastName = "Jackman"}
                        }
                },

               new Movie
               {
                   Id = 4,
                   Title = "The Hobbit: An Unexpected Journey",
                   Year = 2012,
                   LengthInMinutes = 169,
                   Format = "Dvd",
                   Genre = "Action",
                   Rating = 5,
                   IsFavorited = false,
                   Actors = new List<Actor>{
                            new Actor{Id = 5, FirstName = "Martin", MiddleInitial ="S", LastName = "Freeman"},
                            new Actor {Id = 13, FirstName = "Ian", MiddleInitial ="R", LastName = "McKellen"},
                            new Actor {Id = 14, FirstName = "Richard", MiddleInitial ="T", LastName = "Armitage"}
                        }
               },

             new Movie
             {
                 Id = 5,
                 Title = "Madea's Witness Protection",
                 Year = 2012,
                 LengthInMinutes = 114,
                 Format = "Cloud",
                 Genre = "Comedy",
                 Rating = 4,
                 IsFavorited = false,
                 Actors = new List<Actor>{
                           new Actor{Id = 6, FirstName = "Tyler", MiddleInitial ="L", LastName = "Perry"},
                           new Actor{Id = 11, FirstName = "Eugene", MiddleInitial ="L", LastName = "Levy"}
                       }
             },

             new Movie
             {
                 Id = 6,
                 Title = "Les Miserables",
                 Year = 2012,
                 LengthInMinutes = 142,
                 Format = "Blue Ray",
                 Genre = "Musical",
                 Rating = 3,
                 IsFavorited = false,
                 Actors = new List<Actor>{
                            new Actor {Id = 7, FirstName = "Kelly", MiddleInitial ="R", LastName = "Macdonald"}
                        }
             },

             new Movie
             {
                 Id = 7,
                 Title = "Brave",
                 Year = 2012,
                 LengthInMinutes = 93,
                 Format = "Computer",
                 Genre = "Family",
                 Rating = 4,
                 IsFavorited = false,
                 Actors = new List<Actor>{
                            new Actor{Id = 8, FirstName = "Ben", MiddleInitial ="D", LastName = "Stiller"},
                            new Actor {Id = 15, FirstName = "Billy", MiddleInitial ="B", LastName = "Connolly"}
                        }
             },

             new Movie
             {
                 Id = 8,
                 Title = "Madagascar 3: Europe's Most Wanted",
                 Year = 2012,
                 LengthInMinutes = 93,
                 Format = "Dvd",
                 Genre = "Family",
                 Rating = 5,
                 IsFavorited = true,
                 Actors = new List<Actor>{
                            new Actor{Id = 9, FirstName = "Christian", MiddleInitial ="B", LastName = "Bale"},
                        }
             },

             new Movie
             {
                 Id = 9,
                 Title = "The Dark Knight Rises",
                 Year = 2012,
                 LengthInMinutes = 165,
                 Format = "Cloud",
                 Genre = "Action",
                 Rating = 4,
                 IsFavorited = false,
                 Actors = new List<Actor>{
                            new Actor{Id = 10, FirstName = "Anne", MiddleInitial ="W", LastName = "Hathaway"}
                        }
             },

             new Movie
             {
                 Id = 10,
                 Title = "The Hunger Games",
                 Year = 2012,
                 LengthInMinutes = 142,
                 Format = "Blue Ray",
                 Genre = "Action",
                 Rating = 5,
                 IsFavorited = true,
                 Actors = new List<Actor>{
                            new Actor{Id = 12, FirstName = "Denise", MiddleInitial ="F", LastName = "Richards"}
                        }
             }

             );

            var actors = context.Actors.ToList();
            var movies = context.Movies.ToList();
            foreach (var actor in actors)
                foreach (var movie in movies)
                    foreach (var movieActor in movie.Actors)
                        if (actor.Id == movieActor.Id)
                            actor.Movies.Add(movie);
            SeedMembership();
        }
    }
}