using System.Diagnostics;

public class KundeKartotekTest
{
	private IKundeKartotek _kundeKartotek;

	public KundeKartotekTest(IKundeKartotek kundeKartotek)
	{
		_kundeKartotek = kundeKartotek;
	}

	public void TestKundeKartotek()
	{
		Kunde k1 = new Kunde(1, "Anne", 3);
		Kunde k2 = new Kunde(2, "Bent", 4);
		Kunde k3 = new Kunde(3, "Carl", 0);
		Kunde k4 = new Kunde(4, "Dina", 7);
		Kunde k5 = new Kunde(5, "Erik", 0);
		Kunde k6 = new Kunde(6, "Finn", 1);

		// KundeKartotekList kundeKartotek = new KundeKartotekList();
		// KundeKartotekDictionary kundeKartotek = new KundeKartotekDictionary();

		_kundeKartotek.OpretKunde(k1);
		_kundeKartotek.OpretKunde(k2);
		_kundeKartotek.OpretKunde(k3);
		_kundeKartotek.OpretKunde(k4);
		_kundeKartotek.OpretKunde(k5);
		_kundeKartotek.OpretKunde(k6);

		UdskrivInfoOmKundeKartotek("Efter første oprettelse (6 kunder oprettet)");


		Kunde k7 = new Kunde(7, "Gert", 5);
		Kunde k8 = new Kunde(3, "Curt", 3); // NB: Id allerede brugt

		_kundeKartotek.OpretKunde(k7);
		_kundeKartotek.OpretKunde(k8);

		UdskrivInfoOmKundeKartotek("Efter to nye kunder forsøgt oprettet");


		Kunde? kundeA = _kundeKartotek.FindKunde(2);
		Kunde? kundeB = _kundeKartotek.FindKunde(9); // NB: Id findes ikke

		Console.WriteLine("Prøver at finde to kunder...");
		UdskrivInfoOmKunde(kundeA);
		UdskrivInfoOmKunde(kundeB);
		Console.WriteLine();


		bool sletKunde5 = _kundeKartotek.SletKunde(5);
		bool sletKunde8 = _kundeKartotek.SletKunde(8); // NB: Id findes ikke

		Console.WriteLine("Prøver at slette to kunder...");
		Console.WriteLine($"Kunde med id 5 blev slettet: {sletKunde5}");
		Console.WriteLine($"Kunde med id 8 blev slettet: {sletKunde8}");
		Console.WriteLine();

		UdskrivInfoOmKundeKartotek("Efter to kunder forsøgt slettet");
	}

	public long StressTest(int n, int k)
	{
		Random rng = new Random();
		Stopwatch sw = Stopwatch.StartNew();

		// 1) Indsæt N kunder, id = 1 til N
		for (int i = 0; i < n; i++)
		{
			_kundeKartotek.OpretKunde(new Kunde(i, "TEST", 2));
		}

		// 2) Kald FindKunde k gange
		sw.Restart();
		for (int i = 0; i < k; i++)
		{
			int id = rng.Next(n);
			_kundeKartotek.FindKunde(id);
		}
		sw.Stop();

		return sw.ElapsedMilliseconds;
	}

	private void UdskrivInfoOmKunde(Kunde? kunde)
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

	private void UdskrivInfoOmKundeKartotek(string header)
	{
		Console.WriteLine($" ------- {header} --------");
		Console.WriteLine();
		Console.WriteLine($"Det totale antal kunder er {_kundeKartotek.AntalKunder}");

		Console.WriteLine();
		Console.WriteLine($"Det totale antal ordrer er {_kundeKartotek.TotaltAntalOrdrer}");

		Console.WriteLine();
		Console.WriteLine($"Dette er kunderne i kartoteket:");
		_kundeKartotek.UdskrivKunder();
		Console.WriteLine();
	}
}
