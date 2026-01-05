
Kunde k1 = new Kunde(1, "Anne", 3);
Kunde k2 = new Kunde(2, "Bent", 4);
Kunde k3 = new Kunde(3, "Carl", 0);
Kunde k4 = new Kunde(4, "Dina", 7);
Kunde k5 = new Kunde(5, "Erik", 0);
Kunde k6 = new Kunde(6, "Finn", 1);

// KundeKartotekList kundeKartotek = new KundeKartotekList();
KundeKartotekDictionary kundeKartotek = new KundeKartotekDictionary();

kundeKartotek.OpretKunde(k1);
kundeKartotek.OpretKunde(k2);
kundeKartotek.OpretKunde(k3);
kundeKartotek.OpretKunde(k4);
kundeKartotek.OpretKunde(k5);
kundeKartotek.OpretKunde(k6);

UdskrivInfoOmKundeKartotek("Efter første oprettelse (6 kunder oprettet)");


Kunde k7 = new Kunde(7, "Gert", 5);
Kunde k8 = new Kunde(3, "Curt", 3); // NB: Id allerede brugt

kundeKartotek.OpretKunde(k7);
kundeKartotek.OpretKunde(k8);

UdskrivInfoOmKundeKartotek("Efter to nye kunder forsøgt oprettet");


Kunde? kundeA = kundeKartotek.FindKunde(2);
Kunde? kundeB = kundeKartotek.FindKunde(9); // NB: Id findes ikke

Console.WriteLine("Prøver at finde to kunder...");
UdskrivInfoOmKunde(kundeA);
UdskrivInfoOmKunde(kundeB);
Console.WriteLine();


bool sletKunde5 = kundeKartotek.SletKunde(5);
bool sletKunde8 = kundeKartotek.SletKunde(8); // NB: Id findes ikke

Console.WriteLine("Prøver at slette to kunder...");
Console.WriteLine($"Kunde med id 5 blev slettet: {sletKunde5}");
Console.WriteLine($"Kunde med id 8 blev slettet: {sletKunde8}");
Console.WriteLine();

UdskrivInfoOmKundeKartotek("Efter to kunder forsøgt slettet");



void UdskrivInfoOmKunde(Kunde? kunde)
{
    if (kunde == null)
    {
        Console.WriteLine($"Kunde-reference var null");
    }
    else
    {
        Console.WriteLine(kunde.SomTekst());
    }
}

void UdskrivInfoOmKundeKartotek(string header)
{
    Console.WriteLine($" ------- {header} --------");
    Console.WriteLine();
    Console.WriteLine($"Det totale antal kunder er {kundeKartotek.AntalKunder}");

    Console.WriteLine();
    Console.WriteLine($"Det totale antal ordrer er {kundeKartotek.TotaltAntalOrdrer}");

    Console.WriteLine();
    Console.WriteLine($"Dette er kunderne i kartoteket:");
    kundeKartotek.UdskrivKunder();
    Console.WriteLine();
}