
public class Produkt
{
    public int Id { get; }
    public string Navn { get; }
    public double Pris { get; set; }

    public Produkt(int id, string navn, double pris)
    {
        Id = id;
        Navn = navn;
        Pris = pris;
    }

    public string SomTekst()
    {
        return $"Produkt {Id} : {Navn}, koster {Pris:F02} kr.";
    }
}
