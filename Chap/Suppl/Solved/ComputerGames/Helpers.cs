
public class Helpers // Færdig
{
	public static string ListOfGamesToString(List<Game> games, string prefix)
	{
		string str = "\n";

		foreach (Game game in games)
		{
			str += $"{prefix}{game}\n";
		}

		return str;
	}

	public static List<GameCategory> GameGategoriesAsList()
	{
		return Enum.GetValues<GameCategory>().ToList();
	}
}
