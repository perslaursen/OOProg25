
public interface IComputer // Færdig
{
	/// <summary>
	/// Størrelsen (i GB) på computerens SSD.
	/// </summary>
	int SSDSize { get; }

	/// <summary>
	/// Hvor meget plads (i GB) er brugt af computerens SSD.
	/// </summary>
	int UsedStorage { get; }

	/// <summary>
	/// Hvor meget ledig plads (i GB) er der til rådighed på computerens SSD.
	/// </summary>
	int FreeStorage { get; }

	/// <summary>
	/// Hvor mange spil er p.t. installeret.
	/// </summary>
	int NoOfGamesInstalled { get; }

	/// <summary>
	/// Returnerer true hvis et spil med den givne title er installeret,
	/// ellers returneres false.
	/// </summary>
	bool IsInstalled(string title);

	/// <summary>
	/// Returnerer true hvis det givne spil kan installeres 
	/// (et spil kan installeres, hvis det ikke fylder mere 
	/// end den ledige plads på computerens SSD),
	/// ellers returneres false.
	/// </summary>
	bool CanInstall(Game game);

	/// <summary>
	/// Prøver at installere det givne spil, hvis det er muligt (jf. CanInstall).
	/// Returnerer true hvis spillet blev installeret, ellers returneres false.
	/// </summary>
	bool Install(Game game);

	/// <summary>
	/// Returnerer det spil der matcher den givne title.
	/// Hvis intet spil matcher, returneres null.
	/// </summary>
	Game? GetGame(string title);

	/// <summary>
	/// Returnerer antallet af spil der matcher den givne GameCategory.
	/// </summary>
	int GetGamesCountInCategory(GameCategory category);

	/// <summary>
	/// Returnerer de spil der matcher den givne GameCategory.
	/// </summary>
	List<Game> GetGamesInCategory(GameCategory category);
}
