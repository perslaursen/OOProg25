
/// <summary>
/// Implementation af et kunde-kartotek ved brug af Dictionary-klassen
/// </summary>
public class KundeKartotekDictionary : IKundeKartotek
{

	private Dictionary<int, Kunde> _kunder;

    /// <summary>
    /// Returnerer det totale antal kunder i kartoteket
    /// </summary>
    public int AntalKunder
    {
		get
		{
			return _kunder.Count; // IFT List: samme
		}
	}

    /// <summary>
    /// Returnerer det totale antal ordrer for kunderne i kartoteket
    /// </summary>
    public int TotaltAntalOrdrer
    {
		get
		{
			int total = 0;

			foreach (var keyValPair in _kunder) // IFT List: list sværere
			{
				Kunde k = keyValPair.Value;
				total = total + k.AntalOrdrer;
			}

			return total;
		}
	}

    public KundeKartotekDictionary()
    {
        _kunder = new Dictionary<int, Kunde>();
    }

    public void OpretKunde(Kunde kunde)
    {
		if (FindKunde(kunde.Id) == null) // IFT List: samme
		{
			_kunder.Add(kunde.Id, kunde);
		}
	}

    public bool SletKunde(int id)
    {
        return _kunder.Remove(id); // IFT List: betydeligt nemmere
	}

    public Kunde? FindKunde(int id)
    {
        if (_kunder.ContainsKey(id))
        {
            return _kunder[id];
        }
        else
        {
			return null; // TODO
		}

		// eller:
		//return _kunder.ContainsKey(id) ? _kunder[id] : null;
	}

	public void UdskrivKunder()
    {
		foreach (var keyValPair in _kunder)
		{
			Console.WriteLine(keyValPair.Value.SomTekst());
		}

		// eller:
		//foreach (Kunde kunde in _kunder.Values)
		//{
		//	Console.WriteLine(kunde.SomTekst());
		//}
	}
}
