
public class Ordre
{
	public Produkt Produktet { get; }
	public int Antal { get; }
	public double SamletPris
	{
		get { return Produktet.Pris * Antal; }
	}

	public Ordre(Produkt produktet, int antal)
	{
		Produktet = produktet;
		Antal = antal;
	}
}
