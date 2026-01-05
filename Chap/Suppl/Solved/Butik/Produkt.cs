
public class Produkt
{
    public int Id { get; }
    public string Navn { get; }
    public double Pris { get; set; }
	public int LagerBeholdning { get; set; }
    public bool ErIRestOrdre 
    { 
        get { return LagerBeholdning <= 0; } 
    }

	public Produkt(int id, string navn, double pris, int lagerBeholdning)
	{
		Id = id;
		Navn = navn;
		Pris = pris;
		LagerBeholdning = lagerBeholdning;
	}
}
