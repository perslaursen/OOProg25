
public class Computer : IComputer
{
	/// <summary>
	/// Dictionary, da det antages at Title er nøgle for Game.
	/// </summary>
	private Dictionary<string, Game> _games;

	/// <summary>
	/// Størrelsen (i GB) på computerens SSD.
	/// -> Almindelig property
	/// </summary>
	public int SSDSize { get; }

	/// <summary>
	/// Hvor meget plads (i GB) er brugt af computerens SSD.
	/// -> Beregnet property, beregnet ud fra de installerede Games.
	/// </summary>
	public int UsedStorage
	{
		get 
		{
			int usedStorage = 0;

			foreach (Game game in _games.Values)
			{
				usedStorage = usedStorage + game.Size;
			}

			return usedStorage;
		}
	}

	/// <summary>
	/// Hvor meget ledig plads (i GB) er der til rådighed på computerens SSD.
	/// -> Beregnet property.
	/// </summary>
	public int FreeStorage
	{
		get { return SSDSize - UsedStorage; }
	}

	/// <summary>
	/// Hvor mange spil er p.t. installeret.
	/// -> Beregnet property, beregnet ud fra de installerede Games.
	/// </summary>
	public int NoOfGamesInstalled
	{
		get { return _games.Count; }
	}

	/// <summary>
	/// Constructor, behøver kun denne ene parameter.
	/// </summary>
	public Computer(int ssdSize)
	{
		SSDSize = ssdSize;
		_games = new Dictionary<string, Game>();
	}


	public bool CanInstall(Game game)
	{
		// Spil kan installeres hvis der er plads til det,
		// og det ikke er installeret i forvejen.
		return (!IsInstalled(game.Title)) && FreeStorage >= game.Size;
	}

	public Game? GetGame(string title)
	{
		// Brug den givne title til opslag i Dictionary.
		if (_games.ContainsKey(title))
		{
			return _games[title];
		}
		else
			return null;
	}

	public int GetGamesCountInCategory(GameCategory category)
	{
		// Ret simpel, når først GetGamesInCategory er implementeret
		return GetGamesInCategory(category).Count;
	}

	public List<Game> GetGamesInCategory(GameCategory category)
	{
		List<Game> games = new List<Game>();

		// Filtrér de Games ud, hvor Category er lig den givne category.
		foreach (Game game in _games.Values)
		{
			if (game.Category == category)
				games.Add(game);
		}

		return games;
	}

	public bool Install(Game game)
	{
		// Hvis CanInstall returnerer true, indsæt det nye Game i Dictionary.
		if (CanInstall(game))
		{
			_games[game.Title] = game;
			return true;
		}
		else
			return false;
	}

	public bool IsInstalled(string title)
	{
		return _games.ContainsKey(title);
	}

	public override string ToString()
	{
		string str =  $"PC med {SSDSize} GB SSD ({FreeStorage} GB fri), {NoOfGamesInstalled} spil installeret\n";

		// Denne foreach kan udkommenteres, hvis man ikke ønsker dette
		// detaljeniveau i ToString.
		foreach (GameCategory category in Helpers.GameGategoriesAsList())
		{
			if (GetGamesCountInCategory(category) > 0)
			{
				str += category;
				str += $"{Helpers.ListOfGamesToString(GetGamesInCategory(category), "  ")}";
			}
		}

		return str;
	}
}

