using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeaQuest.Models.State;
using ZeaQuest.Models;
using Microsoft.AspNetCore.Mvc;
#nullable disable

namespace ZeaQuest.Pages
{
    public class ChooseHeroModel : PageModel
    {
        private IGameState _gameState;

		[BindProperty(SupportsGet = true)]
		public int ActiveHeroOffset { get; set; }

		public List<Hero> Heroes { get; private set; }

        public ChooseHeroModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void OnGet()
        {
            Heroes = _gameState.HeroRepository.GetAll();

            foreach (Hero hero in Heroes)
            {
                hero.Reset();
            }
        }

        /// <summary>
        /// Handler for the Select button, sets the chosen Hero
        /// as the ChosenHero in the game state, and then redirects
        /// to the "Choose Weapon" page.
        /// </summary>
        public IActionResult OnGetSetHero(int id)
        {
            _gameState.ChosenHero = _gameState.HeroRepository.Get(id);
            return RedirectToPage("ChooseWeapon");
        }
    }
}
