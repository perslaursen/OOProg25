using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeaQuest.Models;
using ZeaQuest.Models.Base;
using ZeaQuest.Models.State;

#nullable disable

namespace ZeaQuest.Pages
{
	public class ChooseArmorModel : PageModel
	{
		private IGameState _gameState;

		[BindProperty(SupportsGet = true)]
		public ArmorType ActiveTab { get; set; }

		public List<Armor> ArmorList { get; private set; }
		public List<bool> ChosenArmor { get; private set; }
		public Hero ChosenHero { get; private set; }

		public List<ArmorType> ArmorTypeList { get; } = ArmorTypes.GetAll();

		public ChooseArmorModel(IGameState gameState)
		{
			_gameState = gameState;
		}

		public void OnGet()
		{
			OnGetInit();
			ChosenHero.SetArmor(CalcChosenArmor());
		}

		/// <summary>
		/// Handler for the Select/Selected button, toggles the selection
		/// of the Armor identified by the id, and updates the Armor set
		/// for the ChosenHero accordingly.
		/// </summary>
		public IActionResult OnGetUpdateSelection(int id, ArmorType activeTab)
		{
			OnGetInit();

			if (!IsSelected(id) && (SelectedInGroup(id) != null))
			{
				// Der er valgt andet Armor i ArmorType => unselct valgte
				int chosenId = SelectedInGroup(id).Id;
				ChosenArmor[chosenId] = !ChosenArmor[chosenId];
			}

			ChosenArmor[id] = !ChosenArmor[id];
			_gameState.ArmorRepository.SetSelection(ChosenArmor);

			ChosenHero.SetArmor(CalcChosenArmor());

			return RedirectToPage(new { activeTab });
		}

		private void OnGetInit()
		{
			ChosenHero = _gameState.ChosenHero;
			ArmorList = _gameState.ArmorRepository.GetAll();
			ChosenArmor = new List<bool>(_gameState.ArmorRepository.GetSelection());
		}

		/// <summary>
		/// Calculates the actual Armor selection, based on the selection in the UI.
		/// </summary>
		private List<Armor> CalcChosenArmor()
		{
			List<Armor> chosenArmorList = new List<Armor>();

			for (int i = 0; i < ArmorList.Count; i++)
			{
				if (ChosenArmor[i])
					chosenArmorList.Add(ArmorList[i]);
			}

			return chosenArmorList;
		}

		private bool IsSelected(int id)
		{
			return ChosenArmor[id];
		}

		private Armor SelectedInGroup(int id)
		{
			ArmorType aType = ArmorList[id].ArmorType;

			return ArmorList.FirstOrDefault(a => a.ArmorType == aType && IsSelected(a.Id));
		}

		public bool AnySelectedInGroup(ArmorType aType)
		{
			return ArmorList.Any(a => a.ArmorType == aType && IsSelected(a.Id));
		}
	}
}
