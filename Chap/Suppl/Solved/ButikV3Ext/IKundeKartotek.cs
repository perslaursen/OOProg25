public interface IKundeKartotek
{
	int AntalKunder { get; }
	int TotaltAntalOrdrer { get; }

	Kunde? FindKunde(int id);
	void OpretKunde(Kunde kunde);
	bool SletKunde(int id);
	void UdskrivKunder();
}