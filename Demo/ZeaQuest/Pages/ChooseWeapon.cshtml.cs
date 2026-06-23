using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeaQuest.Models;
using ZeaQuest.Models.Base;
using ZeaQuest.Models.State;

#nullable disable

namespace ZeaQuest.Pages
{
    public class ChooseWeaponModel : PageModel
    {
        private IGameState _gameState;

		[BindProperty(SupportsGet = true)]
		public int ActiveWeaponOffset { get; set; }

		public List<Weapon> Weapons { get; private set; }
        public Hero ChosenHero { get; private set; }

        public ChooseWeaponModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void OnGet()
        {
            Weapons = _gameState.WeaponRepository.GetAll();
            ChosenHero = _gameState.ChosenHero;
        }

        /// <summary>
        /// Handler for the Select button, sets the chosen Weapon
        /// as Weapon for the ChosenHero in the game state, and then 
        /// redirects to the "Choose Armor" page.
        /// </summary>
        public IActionResult OnGetSetWeapon(int id)
        {
            _gameState.ChosenHero.Weapon = _gameState.WeaponRepository.Get(id);
            return RedirectToPage("ChooseArmor");
        }
    }
}
