using GameZone.Contracts;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Globalization;
using static GameZone.Common.Constants.ValidationConstants;
using static GameZone.Common.Constants.ErrorMessages;

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

        private string GetUserId()
        {
            return _user.GetUserId(User);
        }
    }
}
