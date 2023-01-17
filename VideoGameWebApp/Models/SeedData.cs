using Microsoft.EntityFrameworkCore;
using VideoGameWebApp.Data;

namespace VideoGameWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VideoGameWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<VideoGameWebAppContext>>()))
            {
                if (context == null || context.VideoGame == null)
                {
                    throw new ArgumentException("Null VideoGameWebAppContext");
                }
                if (context.VideoGame.Any())
                {
                    return;   // DB has been seeded
                }


                context.VideoGame.AddRange(
                    new VideoGame
                    {
                        Title = "The Legend of Zelda: Breath of the Wild",
                        Genre = "Action-Adventure",
                        Platform = "Nintendo Switch",
                        Publisher = "Nintendo",
                        Price = 59.99M,
                        Rating = "E10+"
                    },

                    new VideoGame
                    {
                        Title = "Super Mario Odyssey",
                        Genre = "Platformer",
                        Platform = "Nintendo Switch",
                        Publisher = "Nintendo",
                        Price = 59.99M,
                        Rating = "E10+"
                    },

                    new VideoGame
                    {
                        Title = "Super Smash Bros. Ultimate",
                        Genre = "Fighting",
                        Platform = "Nintendo Switch",
                        Publisher = "Nintendo",
                        Price = 59.99M,
                        Rating = "E10+"
                    },

                    new VideoGame
                    {
                        Title = "Super Mario Party",
                        Genre = "Party",
                        Platform = "Nintendo Switch",
                        Publisher = "Nintendo",
                        Price = 59.99M,
                        Rating = "E10+"
                    },

                    new VideoGame
                    {
                        Title = "Mario Kart 8 Deluxe",
                        Genre = "Racing",
                        Platform = "Nintendo Switch",
                        Publisher = "Nintendo",
                        Price = 59.99M,
                        Rating = "E10+"
                    }



                );
                context.SaveChanges();

            }
        }


    }
}
