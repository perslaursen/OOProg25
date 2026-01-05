
// Kunde-objekter oprettes
Kunde k1 = new Kunde(1, "Anne", 6);
Kunde k2 = new Kunde(2, "Bent", 8);
Kunde k3 = new Kunde(3, "Carl", 0);
Kunde k4 = new Kunde(4, "Dina", 3);
Kunde k5 = new Kunde(5, "Erik", 0);
Kunde k6 = new Kunde(6, "Finn", 5);

// Kunde-objekterne sættes ind i kunde-listen. 
List<Kunde> kundeListe = new List<Kunde>();
kundeListe.Add(k1);
kundeListe.Add(k2);
kundeListe.Add(k3);
kundeListe.Add(k4);
kundeListe.Add(k5);
kundeListe.Add(k6);



// 1) Udskriv alle kunderne i kunde-listen. Metoden SomTekst()
//    i Kunde-klassen kan nok hjælpe her.
foreach (Kunde kunde in kundeListe)
{
	Console.WriteLine(kunde.SomTekst());
}




// 2) Hvor mange kunder har 0 ordrer?
int kunderMedNulOrdrer = 0;

// Her skal du skrive kode, der finder den rigtige værdi for
// kunderMedNulOrdrer. Det kræver nok, at du løber kunde-listen
// igennem med en repetition-statement.
foreach (Kunde kunde in kundeListe)
{
	if (kunde.AntalOrdrer == 0)
	{
		kunderMedNulOrdrer++;
	}
}

Console.WriteLine();
Console.WriteLine($"{kunderMedNulOrdrer} kunder har 0 ordrer");
Console.WriteLine();




// 3) Hvor mange ordrer har kunderne totalt?
int totaltAntalOrdrer = 0;

// Her skal du skrive kode, der finder den rigtige værdi for
// totaltAntalOrdrer. Det kræver nok, at du løber kunde-listen
// igennem med en repetition-statement.
foreach (Kunde kunde in kundeListe)
{
	totaltAntalOrdrer = totaltAntalOrdrer + kunde.AntalOrdrer;
}

Console.WriteLine();
Console.WriteLine($"Kunderne har totalt {totaltAntalOrdrer} ordrer");
Console.WriteLine();





// Produkt-objekter oprettes
Produkt p1 = new Produkt(1, "Taske", 399);
Produkt p2 = new Produkt(2, "Jakke", 1479);
Produkt p3 = new Produkt(3, "T-shirt", 149);
Produkt p4 = new Produkt(4, "Handsker", 249);
Produkt p5 = new Produkt(5, "Støvler", 1199);


// Produkt-objekterne sættes ind i produkt-listen. 
List<Produkt> produktListe = new List<Produkt>();
produktListe.Add(p1);
produktListe.Add(p2);
produktListe.Add(p3);
produktListe.Add(p4);
produktListe.Add(p5);



// 4) Udskriv alle produkterne i produkt-listen. Metoden SomTekst()
//    i Produkt-klassen kan nok hjælpe her.
foreach (Produkt produkt in produktListe)
{
	Console.WriteLine(produkt.SomTekst());
}



// 5) Hvor mange produkter er "dyre", defineret som at de koster
//    mere end 1000 kr.?
int dyreProdukter = 0;

// Her skal du skrive kode, der finder den rigtige værdi for
// dyreProdukter. Det kræver nok, at du løber produkt-listen
// igennem med en repetition-statement.
foreach (Produkt produkt in produktListe)
{
	if (produkt.Pris > 1000)
	{
		dyreProdukter++;
	}
}

Console.WriteLine();
Console.WriteLine($"{dyreProdukter} produkter er dyre");
Console.WriteLine();




// 6) Hvad er navnet på det billigste produkt?
string billigsteProdukt = "Tja...";

// Her skal du skrive kode, der finder den rigtige værdi for
// billigsteProdukt. Det kræver nok, at du løber produkt-listen
// igennem med en repetition-statement.
billigsteProdukt = produktListe[0].Navn;
double billigstePris = produktListe[0].Pris;

foreach (Produkt produkt in produktListe)
{
	if (produkt.Pris < billigstePris)
	{
		billigstePris = produkt.Pris;
		billigsteProdukt = produkt.Navn;
	}
}

Console.WriteLine();
Console.WriteLine($"{billigsteProdukt} er det billigste produkt");
Console.WriteLine();