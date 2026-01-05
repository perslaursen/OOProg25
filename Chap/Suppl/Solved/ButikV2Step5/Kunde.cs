
public class Kunde
{
	private List<Ordre> _ordrer;

	public int Id { get; }
    public string Navn { get; }

    public int AntalOrdrer 
    {
        get { return _ordrer.Count; }
    }

	public double SamletPrisForOrdrer
	{
		get 
        {
            double samletPris = 0;

            foreach (Ordre ordre in _ordrer)
            {
                samletPris = samletPris + ordre.SamletPris;
            }

            return samletPris;
        }
	}


	public Kunde(int id, string navn)
    {
        Id = id;
        Navn = navn;

		_ordrer = new List<Ordre>();
    }

    public void TilføjOrdre(Ordre ordre)
    {
		_ordrer.Add(ordre);
    }

    public string SomTekst()
    {
        return $"Kunde {Id} : {Navn}, har {AntalOrdrer} ordrer til en samlet pris på {SamletPrisForOrdrer} kr.";
    }

	public string SomTekstMedDetaljer()
	{
		string text = $"Kunde {Id} : {Navn}, har {AntalOrdrer} ordrer til en samlet pris på {SamletPrisForOrdrer} kr.";

        foreach (Ordre ordre in _ordrer)
        {
            text = text + $"\n  {ordre.Produktet.Navn} ({ordre.Antal} stk.)";
        }

        return text;
	}
}
