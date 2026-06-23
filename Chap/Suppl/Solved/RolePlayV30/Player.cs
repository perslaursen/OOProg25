
using System.Linq;

/// <summary>
/// Repræsenterer en Player.
/// En Player kan eje et antal Armor-objekter.
/// </summary>
public class Player
{
	public const double ResistanceModifier = 50.0;

	public string Name { get; }
	public double HealthPoints { get; private set; }
	public bool IsDead { get { return HealthPoints <= 0; } }

	private List<Armor> _armorList;
	private double _initialHealthPoints;

	public Player(string name, int healthPoints)
	{
		Name = name;
		HealthPoints = healthPoints;

		_armorList = new List<Armor>();
		_initialHealthPoints = HealthPoints;
	}

	/// <summary>
	/// Tilføj det angivne Armor-objekt til Player, men KUN
	/// hvis Player ikke i forvejen ejer dette stykke Armor.
	/// Hvis Player allerede ejer dette stykke Armor, skal der
	/// i stedet kastes en ArgumentException.
	/// </summary>
	public void AddArmor(Armor armor)
	{
		if (_armorList.Contains(armor))
		{
			throw new ArgumentException($"Player already has armor with Id = {armor.Id}");
		}

		_armorList.Add(armor);
	}

	/// <summary>
	/// En Players samlede Resistance overfor en given DamageType udregnes 
	/// som summen af denne Resistance for de enkelte stykker Armor.
	/// Dvs. hvis en Player har tre stykker Armor med denne Resistance:
	///    1) Physical = 15, Fire = 20
	///    2) Physical = 25, Frost = 10
	///    3) Physical = 15, Fire = 15
	/// vil den samlede Resistance være:
	///    Physical = 15 + 25 + 15 = 55
	///    Fire = 20 + 15 = 35
	///    Frost = 10
	public double GetResistance(DamageType damageType)
	{
		// Select transformerer listen af Armor-objekter til
		// en collection af Resistance-værdier (af typen double).
		// På denne collection giver det mening at udregne summen.
		return _armorList.Sum(a => a.GetResistance(damageType));
	}

	/// <summary>
	/// Reset HealthPoints til den værdi der blev angivet 
	/// da Player-objektet blev oprettet.
	/// </summary>
	public void ResetHealth()
	{
		HealthPoints = _initialHealthPoints;
	}

	/// <summary>
	/// Håndterer effekten af den indkomne Damage.
	/// Hvis Player allerede er død, skal der ikke ske noget.
	/// Hvis Player er i live, udregnes den "resulterende damage",
	/// dvs. den damage Player rent faktisk modtager, når der er 
	/// taget hensyn til Resistances.
	/// Denne "resulterende damage" trækkes så fra HealthPoints.
	/// </summary>
	public void ReceiveDamage(Damage damage)
	{
		if (IsDead)
			return;

		HealthPoints -= CalculateResultingDamage(damage);
	}

	public override string ToString()
	{
		string str = $"Player {Name}, currently has {HealthPoints:F02} HP\n";
		str += "Armor:\n ";
		str += string.Join(" \n ", _armorList);
		str += "\nResistances:\n ";
		str += string.Join(" \n ", Helpers.DamageTypeList.Select(dmgType => $"{dmgType} = {GetResistance(dmgType)}"));
		str += "\n";
		return str;
	}

	/// <summary>
	/// Beregner en "damage factor" ud fra resistanceScore.
	/// Jo højere resistanceScore, jo lavere "damage factor".
	/// Denne "damage factor" ganges så sammen med den indgående damage,
	/// for at finde den damage Player reelt modtager.
	/// NB: Denne metode er lavet "public static", så man kan teste den
	/// uden at oprette et Player-objekt.
	/// </summary>
	public static double ResistanceToDamageFactor(double resistanceScore)
	{
		return ResistanceModifier/(resistanceScore + ResistanceModifier);
	}

	/// <summary>
	/// Implementerer selve beregningen af den "resulterende damage",
	/// dvs. den damage Player rent faktisk modtager, når der er 
	/// taget hensyn til Resistance.
	/// For hver af de indgående damage-typer vil man skulle:
	///   1) Udregne samlet Resistance for denne damage-type
	///   2) Udregne "damage factor" ud fra samlet Resistance
	///   3) Gange denne "damage factor" sammen med den indkomne damage,
	///      hvorved man får den "resulterende damage" for denne damage-type.
	/// For at finde den totale "resulterende damage" skal man så til sidst
	/// summere alle "resulterende damage" for de enkelte damage-typer.
	/// </summary>
	private double CalculateResultingDamage(Damage damage)
	{
		//return damage
		//	.AsDictionary() // kvp.Key er "damage type", kvp.Value er "damage points"
		//	.Select(kvp => kvp.Value * ResistanceToDamageFactor(GetResistance(kvp.Key)))
		//	.Sum();

		// Simplere formulering, der bruger IncomingDamageToResultingDamage
		return damage
			.AsDictionary()
			.Select(kvp => IncomingDamageToResultingDamage(kvp.Key, kvp.Value))
			.Sum();
	}

	/// <summary>
	/// Man kunne indføre denne som hjælpe-metode, og derved gøre
	/// formuleringen af CalculateResultingDamage lidt simplere.
	/// </summary>
	private double IncomingDamageToResultingDamage(DamageType damageType, double incomingDamage)
	{
		// For den indgående damage-type og damage skal vi:
		//   1) Udregne samlet Resistance for denne damage-type
		double resistance = GetResistance(damageType);

		//   2) Udregne "damage factor" ud fra samlet Resistance
		double damageFactor = ResistanceToDamageFactor(resistance);

		//   3) Gange denne "damage factor" sammen med den indkomne damage,
		//      hvorved man får den "resulterende damage" for denne damage-type.
		double resultingDamage = incomingDamage * damageFactor;

		return resultingDamage;
	}
}
