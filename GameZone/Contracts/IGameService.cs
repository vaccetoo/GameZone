using GameZone.Models;

namespace GameZone.Contracts
{
    public interface IGameService
    {
        Task AddAsync(GameFormViewModel model, DateTime releasedDate, string userId);

        Task<IEnumerable<GameViewModel>> GetAllAsync();

        Task<GameFormViewModel> GetByIdAsync(int id);

        Task<IEnumerable<GameViewModel>> GetGamerGamesAsync(string userId);

        Task<IEnumerable<GenreViewModel>> GetGenresAsync();

        Task UpdateGameAsync(GameFormViewModel model, DateTime releasedDate);
    }
}
