
/// <summary>
/// Repository for Armor-objekter.
/// Fra starten rummer dette Repository fire Armor-objekter 
/// </summary>
public class ArmorRepository
{
	private static int _nextId = 1;
	private Dictionary<int, Armor> _availableArmor;

	public ArmorRepository()
	{
		_availableArmor = new Dictionary<int, Armor>();

		Dictionary<DamageType, double> res1 = new Dictionary<DamageType, double>
		{
			{ DamageType.Physical, 40 }, { DamageType.Fire, 55 }
		};
		Create("Belt of Justice", res1);

		Dictionary<DamageType, double> res2 = new Dictionary<DamageType, double>
		{
			{ DamageType.Physical, 25 }
		};
		Create("Rugged Helmet", res2);

		Dictionary<DamageType, double> res3 = new Dictionary<DamageType, double>
		{
			{ DamageType.Fire, 30 }, { DamageType.Frost, 30 }
		};
		Create("Insulating Boots", res3);

		Dictionary<DamageType, double> res4 = new Dictionary<DamageType, double>
		{
			{ DamageType.Physical, 40 }, { DamageType.Fire, 35 }, { DamageType.Frost, 45 }
		};
		Create("Magnificent Chestplate", res4);
	}

	public Armor Read(int id)
	{
		if (!_availableArmor.ContainsKey(id))
		{
			throw new ArgumentException($"No Armor with Id = {id} found");
		}

		return _availableArmor[id];
	}

	public List<Armor> GetAll()
	{
		return new List<Armor>(_availableArmor.Values);
	}

	public int Create(string description, Dictionary<DamageType, double> resistances)
	{
		Armor a = new Armor(_nextId++, description, resistances);
		_availableArmor.Add(a.Id, a);

		return a.Id;
	}

	public override string ToString()
	{
		string str = "Content of Armor Repository\n----------------------------\n";
		str += string.Join("\n", _availableArmor.Select(kvp => kvp.Value));
		str += "\n";

		return str;
	}
}
