
// 2. Start i klassen Game. Implementér disse elementer i klassen:
public class Game
{
	//a. En property Title af typen string.
	public string Title { get; }

	//b. En property Category af typen GameCategory.
	public GameCategory Category { get; }

	//c. En property Size (spillets størrelse i GB) af typen int.
	public int Size { get; }

	//d. En passende constructor.
	public Game(string title, GameCategory category, int size)
	{
		Title = title;
		Category = category;
		Size = size;
	}

	//e. En ToString-metode (husk override).
	public override string ToString()
	{
		return $"{Title} ({Category}), fylder {Size} GB";
	}
}
