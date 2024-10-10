using GameZone.Contracts;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static GameZone.Common.Constants.ErrorMessages;
using static GameZone.Common.Constants.ValidationConstants;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly UserManager<IdentityUser> _user;

        public GameController(IGameService gameService, UserManager<IdentityUser> user)
        {
            _gameService = gameService;
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<GameViewModel> model = await _gameService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameFormViewModel();

            model.Genres = await _gameService.GetGenresAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameFormViewModel model)
        {
            DateTime releasedDate = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.ReleasedOn, 
                DateTimeFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out releasedDate))
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), InvalidDateErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await _gameService.GetGenresAsync();

                return View(model);
            }

            await _gameService.AddAsync(model, releasedDate, GetUserId());

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var model = await _gameService.GetGamerGamesAsync(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GameFormViewModel model = await _gameService.GetByIdAsync(id);

            model.Genres = await _gameService.GetGenresAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameFormViewModel model)
        {
            DateTime releasedDate = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out releasedDate))
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), InvalidDateErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Genres = await _gameService.GetGenresAsync();

                return View(model);
            }

            await _gameService.UpdateGameAsync(model, releasedDate);

            return RedirectToAction(nameof(All));
        }

        
        public async Task<IActionResult> AddToMyZone(int id)
        {
            await _gameService.AddGamerGameAsync(id, GetUserId());

            return RedirectToAction(nameof(MyZone));
        }

        public async Task<IActionResult> StrikeOut(int id)
        {
            await _gameService.RemoveGamerGameAsync(id, GetUserId());

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _gameService.GetGameDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new DeleteGameViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteGameViewModel model)
        {
            await _gameService.DeleteGameAsync(model);

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return _user.GetUserId(User);
        }
    }
}
