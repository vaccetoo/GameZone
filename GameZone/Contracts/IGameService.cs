using GameZone.Models;

namespace GameZone.Contracts
{
    public interface IGameService
    {
        Task AddAsync(GameFormViewModel model, DateTime releasedDate, string userId);

        Task AddGamerGameAsync(int gameId, string userId);

        Task DeleteGameAsync(DeleteGameViewModel model);

        Task<IEnumerable<GameViewModel>> GetAllAsync();

        Task<GameFormViewModel> GetByIdAsync(int id);

        Task<GameDetailsViewModel> GetGameDetailsAsync(int id);

        Task<IEnumerable<GameViewModel>> GetGamerGamesAsync(string userId);

        Task<IEnumerable<GenreViewModel>> GetGenresAsync();

        Task RemoveGamerGameAsync(int gameId, string userId);

        Task UpdateGameAsync(GameFormViewModel model, DateTime releasedDate);
    }
}
