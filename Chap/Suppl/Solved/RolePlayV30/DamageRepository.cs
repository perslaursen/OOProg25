
/// <summary>
/// Repository for Damage-objekter.
/// Fra starten rummer dette Repository fire Damage-objekter.
/// Dette repository er primært lavet for at kunne udføre tests
/// med prædefinerede Damage-objekter.
/// </summary>
public class DamageRepository
{
	private static int _nextId = 1;
	private Dictionary<int, Damage> _damages;

	public DamageRepository()
	{
		_damages = new Dictionary<int, Damage>();

		Dictionary<DamageType, double> dmg1 = new Dictionary<DamageType, double>
		{
			{ DamageType.Physical, 10 }, { DamageType.Fire, 12 }
		};
		Create(dmg1);

		Dictionary<DamageType, double> dmg2 = new Dictionary<DamageType, double>
		{
			{ DamageType.Physical, 30 },
		};
		Create(dmg2);

		Dictionary<DamageType, double> dmg3 = new Dictionary<DamageType, double>
		{
			{ DamageType.Frost, 24 },
		};
		Create(dmg3);

		Dictionary<DamageType, double> dmg4 = new Dictionary<DamageType, double>
		{
			{ DamageType.Physical, 20 }, { DamageType.Frost, 15 },
		};
		Create(dmg4);
	}

	public Damage Read(int id)
	{
		if (!_damages.ContainsKey(id))
		{
			throw new ArgumentException($"No Damage with Id = {id} found");
		}

		return _damages[id];
	}

	public int Create(Dictionary<DamageType, double> damages)
	{
		Damage d = new Damage(_nextId++, damages);
		_damages.Add(d.Id, d);

		return d.Id;
	}

	public override string ToString()
	{
		string str = "Content of Damage Repository\n----------------------------\n";
		str += string.Join("\n", _damages.Select(kvp => kvp.Value));
		str += "\n";

		return str;
	}
}
