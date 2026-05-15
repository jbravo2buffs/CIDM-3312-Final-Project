using CIDM_3312_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Data
{
    public class GameVaultContext : DbContext
    {
        public GameVaultContext(DbContextOptions<GameVaultContext> options)
            : base(options) { }

        public DbSet<Platform> Platforms { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform { PlatformId = 1, Name = "PlayStation 5", Company = "Sony", ConsoleType = "Console" },
                new Platform { PlatformId = 2, Name = "Xbox Series X", Company = "Microsoft", ConsoleType = "Console" },
                new Platform { PlatformId = 3, Name = "Nintendo Switch", Company = "Nintendo", ConsoleType = "Hybrid" },
                new Platform { PlatformId = 4, Name = "PC", Company = "Multiple", ConsoleType = "Computer" },
                new Platform { PlatformId = 5, Name = "Steam Deck", Company = "Valve", ConsoleType = "Handheld" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, PlatformId = 1, Title = "Spider-Man 2", Genre = "Action", ReleaseYear = 2023, Rating = 9.2m, Status = "Playing" },
                new Game { GameId = 2, PlatformId = 1, Title = "God of War Ragnarok", Genre = "Adventure", ReleaseYear = 2022, Rating = 9.5m, Status = "Finished" },
                new Game { GameId = 3, PlatformId = 1, Title = "Horizon Forbidden West", Genre = "RPG", ReleaseYear = 2022, Rating = 8.8m, Status = "Backlog" },
                new Game { GameId = 4, PlatformId = 1, Title = "Final Fantasy VII Rebirth", Genre = "RPG", ReleaseYear = 2024, Rating = 9.1m, Status = "Wishlist" },
                new Game { GameId = 5, PlatformId = 1, Title = "Gran Turismo 7", Genre = "Racing", ReleaseYear = 2022, Rating = 8.3m, Status = "Owned" },
                new Game { GameId = 6, PlatformId = 2, Title = "Halo Infinite", Genre = "Shooter", ReleaseYear = 2021, Rating = 8.0m, Status = "Finished" },
                new Game { GameId = 7, PlatformId = 2, Title = "Forza Horizon 5", Genre = "Racing", ReleaseYear = 2021, Rating = 9.0m, Status = "Playing" },
                new Game { GameId = 8, PlatformId = 2, Title = "Starfield", Genre = "RPG", ReleaseYear = 2023, Rating = 8.1m, Status = "Backlog" },
                new Game { GameId = 9, PlatformId = 2, Title = "Hi-Fi Rush", Genre = "Rhythm", ReleaseYear = 2023, Rating = 8.7m, Status = "Finished" },
                new Game { GameId = 10, PlatformId = 2, Title = "Sea of Thieves", Genre = "Adventure", ReleaseYear = 2018, Rating = 8.2m, Status = "Playing" },
                new Game { GameId = 11, PlatformId = 3, Title = "The Legend of Zelda: Tears of the Kingdom", Genre = "Adventure", ReleaseYear = 2023, Rating = 9.7m, Status = "Playing" },
                new Game { GameId = 12, PlatformId = 3, Title = "Mario Kart 8 Deluxe", Genre = "Racing", ReleaseYear = 2017, Rating = 9.0m, Status = "Owned" },
                new Game { GameId = 13, PlatformId = 3, Title = "Super Smash Bros. Ultimate", Genre = "Fighting", ReleaseYear = 2018, Rating = 9.1m, Status = "Owned" },
                new Game { GameId = 14, PlatformId = 3, Title = "Metroid Prime Remastered", Genre = "Action", ReleaseYear = 2023, Rating = 8.9m, Status = "Backlog" },
                new Game { GameId = 15, PlatformId = 3, Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseYear = 2020, Rating = 8.5m, Status = "Finished" },
                new Game { GameId = 16, PlatformId = 4, Title = "Baldur's Gate 3", Genre = "RPG", ReleaseYear = 2023, Rating = 9.8m, Status = "Playing" },
                new Game { GameId = 17, PlatformId = 4, Title = "Cyberpunk 2077", Genre = "RPG", ReleaseYear = 2020, Rating = 8.6m, Status = "Backlog" },
                new Game { GameId = 18, PlatformId = 4, Title = "Elden Ring", Genre = "Action RPG", ReleaseYear = 2022, Rating = 9.6m, Status = "Finished" },
                new Game { GameId = 19, PlatformId = 4, Title = "Stardew Valley", Genre = "Simulation", ReleaseYear = 2016, Rating = 9.0m, Status = "Owned" },
                new Game { GameId = 20, PlatformId = 4, Title = "Hades", Genre = "Roguelike", ReleaseYear = 2020, Rating = 9.3m, Status = "Finished" },
                new Game { GameId = 21, PlatformId = 5, Title = "Vampire Survivors", Genre = "Arcade", ReleaseYear = 2022, Rating = 8.7m, Status = "Playing" },
                new Game { GameId = 22, PlatformId = 5, Title = "Dave the Diver", Genre = "Adventure", ReleaseYear = 2023, Rating = 8.9m, Status = "Wishlist" },
                new Game { GameId = 23, PlatformId = 5, Title = "Portal 2", Genre = "Puzzle", ReleaseYear = 2011, Rating = 9.4m, Status = "Finished" },
                new Game { GameId = 24, PlatformId = 5, Title = "Celeste", Genre = "Platformer", ReleaseYear = 2018, Rating = 9.2m, Status = "Backlog" },
                new Game { GameId = 25, PlatformId = 5, Title = "No Man's Sky", Genre = "Survival", ReleaseYear = 2016, Rating = 8.4m, Status = "Owned" },
                new Game { GameId = 26, PlatformId = 4, Title = "Minecraft", Genre = "Sandbox", ReleaseYear = 2011, Rating = 9.1m, Status = "Playing" }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, GameId = 1, ReviewerName = "Bravo", Score = 9, Comment = "Fast combat and fun web swinging make this easy to keep playing.", DatePosted = DateTime.Parse("05/01/2026") },
                new Review { ReviewId = 2, GameId = 2, ReviewerName = "Bravo", Score = 10, Comment = "Great story and boss fights. One of the strongest finished games in the vault.", DatePosted = DateTime.Parse("05/02/2026") },
                new Review { ReviewId = 3, GameId = 7, ReviewerName = "Bravo", Score = 9, Comment = "A relaxing racing game with a huge map and tons of events.", DatePosted = DateTime.Parse("05/03/2026") },
                new Review { ReviewId = 4, GameId = 11, ReviewerName = "Bravo", Score = 10, Comment = "Creative, huge, and easy to get lost in for hours.", DatePosted = DateTime.Parse("05/04/2026") },
                new Review { ReviewId = 5, GameId = 16, ReviewerName = "Bravo", Score = 10, Comment = "Deep choices and strong characters make it feel different every session.", DatePosted = DateTime.Parse("05/05/2026") },
                new Review { ReviewId = 6, GameId = 18, ReviewerName = "Bravo", Score = 10, Comment = "Challenging but rewarding, with memorable exploration.", DatePosted = DateTime.Parse("05/06/2026") },
                new Review { ReviewId = 7, GameId = 20, ReviewerName = "Bravo", Score = 9, Comment = "Quick runs, sharp writing, and great action.", DatePosted = DateTime.Parse("05/07/2026") },
                new Review { ReviewId = 8, GameId = 23, ReviewerName = "Bravo", Score = 9, Comment = "Still one of the best puzzle games to replay.", DatePosted = DateTime.Parse("05/08/2026") }
            );
        }
    }
}
