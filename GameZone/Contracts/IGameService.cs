using GameZone.Models;

namespace GameZone.Contracts
{
    public interface IGameService
    {
        Task AddAsync(GameFormViewModel model, DateTime releasedDate, string userId);
        Task<IEnumerable<GameViewModel>> GetAllAsync();
        Task<IEnumerable<GenreViewModel>> GetGenresAsync();
    }
}
