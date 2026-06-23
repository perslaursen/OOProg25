
/// <summary>
/// Repræsenterer et enkelt stykke "armor".
/// Armor kan give en vis "resistance" overfor Damage af bestemte typer.
/// </summary>
public class Armor
{
	// Rummer den specifikke resistance (for hver Damage-type)
	// for dette stykke Armor, f.eks. [Physical = 18, Fire = 30]
	private Dictionary<DamageType, double> _resistances;

	public int Id { get; }
	public string Description { get; }

	public Armor(int id, string description, Dictionary<DamageType, double> resistances)
	{
		Id = id;
		Description = description;

		_resistances = new Dictionary<DamageType, double>(resistances);
	}

	/// <summary>
	/// Returnerer den specifkke Resistance for den angivne DamageType.
	/// Hvis dette stykke Armor kke har nogen Resistance overfor den 
	/// angivne DamageType, returneres 0 (nul).
	/// </summary>
	public double GetResistance(DamageType damageType)
	{
		return _resistances.ContainsKey(damageType) ? _resistances[damageType] : 0;
	}

	public override string ToString()
	{
		return $"[{Id}] {Description}, Resistances [{Helpers.DictionaryToString(_resistances)}]";
	}
}