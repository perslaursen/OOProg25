
/// <summary>
/// Repræsenterer en Damage, som en Player kan modtage.
/// Damage kan rumme mere end en type damage, f.eks. 
/// [Physical = 10, Frost = 6]
/// </summary>
public class Damage
{
	// Rummer den specifikke damage (for hver Damage-type)
	// for denne Damage, f.eks. [Physical = 10, Frost = 6]
	private Dictionary<DamageType, double> _damages;

	public int Id { get; }

	public Damage(int id, Dictionary<DamageType, double> damages)
	{
		Id = id;

		_damages = new Dictionary<DamageType, double>(damages);
	}

	/// <summary>
	/// Returnerer Damage i form af en Dictionary (DamageType -> double).
	/// </summary>
	public Dictionary<DamageType, double> AsDictionary()
	{
		return new Dictionary<DamageType, double>(_damages);
	}

	public override string ToString()
	{
		return $"[{Id}] Damages [{Helpers.DictionaryToString(_damages)}]";
	}
}
