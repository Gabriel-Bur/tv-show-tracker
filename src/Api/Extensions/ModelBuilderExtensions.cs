using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Show>()
                .HasData(
                new Show() { Id = 1, Name = "The Flash", Description = "Barry Allen is a Central City police forensic scientist with a reasonably happy life, despite the childhood trauma of a mysterious red and yellow being killing his mother and framing his father.", Url = "https://www.episodate.com/tv-show/the-flash", Genres = "Drama,Action,Science-Fiction", StartDate = new DateTime(2014,10,7)},
                new Show() { Id = 2, Name = "Game of Thrones", Description = "Nine noble families fight for control of the mythical land of Westeros. Political and sexual intrigue is pervasive. Robert Baratheon, King of Westeros, asks his old friend Eddard, Lord Stark, to serve as Hand of the King, or highest official.", Url = "https://www.episodate.com/tv-show/game-of-thrones", Genres = "Drama,Adventure,Fantasy", StartDate = new DateTime(2011, 04, 17) },
                new Show() { Id = 3, Name = "Stranger Things", Description = "A love letter to the '80s classics that captivated a generation, <b>Stranger Things</b> is set in 1983 Indiana, where a young boy vanishes into thin air.", Url = "https://www.episodate.com/tv-show/montauk", Genres = "Drama,Science-Fiction,Horror", StartDate = new DateTime(2016, 07, 15) }
                );
        }
    }
}
