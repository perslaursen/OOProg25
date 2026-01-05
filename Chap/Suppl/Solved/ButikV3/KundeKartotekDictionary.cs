
using System.Diagnostics;

/// <summary>
/// Implementation af et kunde-kartotek ved brug af Dictionary-klassen
/// </summary>
public class KundeKartotekDictionary
{
    private Dictionary<int, Kunde> _kunder; // Alle elementer i dette Dictionary har en int som Key, og et Kunde-objekt som Value.

    /// <summary>
    /// Returnerer det totale antal kunder i kartoteket
    /// </summary>
    public int AntalKunder
    {
        get 
        { 
            return _kunder.Count;
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

			foreach (var element in _kunder)
			{
                Kunde kunde = element.Value; // Da Value-delen af dette element jo er et Kunde-objekt.
				total = total + kunde.AntalOrdrer;
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
		if (FindKunde(kunde.Id) != null)
		{
			_kunder.Add(kunde.Id, kunde); // Da Id'et for dette Kunde-objekt jo netop er den relevante key.
		}
	}

    public bool SletKunde(int id) // NB: Ikke nødvendigt at iterere gennem Dictionary!
	{
        return _kunder.Remove(id); // Da Remove netop tager en Key som argument, og returnerer true/false.
    }

    public Kunde? FindKunde(int id) // NB: Ikke nødvendigt at iterere gennem Dictionary!
    {
        if (_kunder.ContainsKey(id))
        {
            return _kunder[id];
        }
        else
        {
			return null;
		}
	}

    public void UdskrivKunder()
    {
		foreach (var element in _kunder)
		{
			Kunde kunde = element.Value; // Da Value-delen af dette element jo er et Kunde-objekt.
			Console.WriteLine(kunde.SomTekst());
		}
	}
}
