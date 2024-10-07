using GameZone.Contracts;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using static GameZone.Common.Constants.ValidationConstants;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly GameZoneDbContext _context;
        public GameService(GameZoneDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GameFormViewModel model, DateTime releasedDate, string userId)
        {
            var entity = new Game()
            {
                Id = model.Id,
                Description = model.Description,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                PublisherId = userId,
                ReleasedOn = releasedDate,
                Title = model.Title
            };

            await _context.Games.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameViewModel>> GetAllAsync()
        {
            return await _context.Games
                .Select(entity => new GameViewModel()
                {
                    Id = entity.Id,
                    Genre = entity.Genre.Name,
                    ImageUrl = entity.ImageUrl,
                    ReleasedOn = entity.ReleasedOn.ToString(DateTimeFormat),
                    Title = entity.Title,
                    Publisher = entity.Publisher.UserName
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GameFormViewModel> GetByIdAsync(int id)
        {
            return await _context.Games
                .Where(g => g.Id == id)
                .Select(g => new GameFormViewModel()
                {
                    Id = g.Id,
                    Description = g.Description,
                    GenreId = g.GenreId,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(DateTimeFormat),
                    Title = g.Title
                })
                .AsNoTracking()
                .FirstAsync();
        }

        public async Task<IEnumerable<GameViewModel>> GetGamerGamesAsync(string userId)
        {
            return await _context.GamersGames
                .Where(gg => gg.GamerId == userId)
                .Select(gg => new GameViewModel()
                {
                    Id = gg.Game.Id,
                    Genre = gg.Game.Genre.Name,
                    ImageUrl = gg.Game.ImageUrl,
                    Publisher = gg.Game.Publisher.UserName,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(DateTimeFormat),
                    Title = gg.Game.Title
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
        {
            return await _context.Genres
                .Select(entity => new GenreViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateGameAsync(GameFormViewModel model, DateTime releasedDate)
        {
            var entity = await _context.Games
                .FindAsync(model.Id);

            if (entity != null)
            {
                entity.Description = model.Description;
                entity.Title = model.Title;
                entity.ReleasedOn = releasedDate;
                entity.GenreId = model.GenreId;
                entity.Id = model.Id;
                entity.ImageUrl = model.ImageUrl;
            }

            await _context.SaveChangesAsync();
        }
    }
}
