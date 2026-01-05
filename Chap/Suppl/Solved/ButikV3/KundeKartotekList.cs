
/// <summary>
/// Implementation af et kunde-kartotek ved brug af List-klassen
/// </summary>
public class KundeKartotekList
{
    private List<Kunde> _kunder;

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

            foreach (Kunde kunde in _kunder)
            {
                total = total + kunde.AntalOrdrer;
            }

            return total;
        }
    }

    public KundeKartotekList()
    {
        _kunder = new List<Kunde>();
    }

    /// <summary>
    /// Opret en Kunde. Kunden tilføjes til kartoteket.
    /// </summary>
    public void OpretKunde(Kunde kunde)
    {
        if (FindKunde(kunde.Id) == null)
        {
            _kunder.Add(kunde);
        }
    }

    /// <summary>
    /// Slet kunden med det givne Id. Hvis der fandtes en sådan Kunde,
    /// returneres true, ellers false.
    /// </summary>
    public bool SletKunde(int id)
    {
        foreach (Kunde kunde in _kunder)
        {
            if (kunde.Id == id)
            {
                _kunder.Remove(kunde);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Find kunden med det givne Id. Hvis der findes en sådan Kunde,
    /// returneres en reference til Kunde-objektet, ellers null.
    /// </summary>
    public Kunde? FindKunde(int id)
    {
        foreach (Kunde kunde in _kunder)
        {
            if (kunde.Id == id)
            {
                return kunde;
            }
        }

        return null;
    }

    /// <summary>
    /// Udskriv alle Kunder.
    /// </summary>
    public void UdskrivKunder()
    {
        foreach (Kunde kunde in _kunder)
        {
            Console.WriteLine(kunde.SomTekst());
        }
    }
}
