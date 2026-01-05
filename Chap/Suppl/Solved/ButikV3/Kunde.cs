
public class Kunde
{
    public int Id { get; }
    public string Navn { get; }
    public int AntalOrdrer { get; set; }

    public Kunde(int id, string navn, int antalOrdrer)
    {
        Id = id;
        Navn = navn;
        AntalOrdrer = antalOrdrer;
    }

    public string SomTekst()
    {
        return $"Kunde {Id} : {Navn}, har {AntalOrdrer} ordrer";
    }
}
