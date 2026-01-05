
Console.WriteLine("Afprøvning af klassen Produkt :");

Produkt p1 = new Produkt(1, "Sko", 650, 4);
Produkt p2 = new Produkt(2, "Jakke", 1295, 0);
Produkt p3 = new Produkt(3, "Støvler", 945, 11);
Produkt p4 = new Produkt(4, "Handsker", 385, 7);


UdskrivProdukt(p1);
UdskrivProdukt(p2);
UdskrivProdukt(p3);
UdskrivProdukt(p4);


void UdskrivProdukt(Produkt p)
{
	Console.WriteLine($"[{p.Id}] {p.Navn}, koster {p.Pris:.00} kr. ({p.LagerBeholdning} på lager)");
}
