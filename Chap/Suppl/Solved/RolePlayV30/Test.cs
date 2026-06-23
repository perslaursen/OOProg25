
public class Test
{
	/// <summary>
	/// Resetter Player HealthPoints, kalder derefter ReceiveDamage med den angivne damage som argument,
	/// og udskriver hvordan Player påvirkes af denne damage.
	/// </summary>
	public static void ExposePlayerToDamage(Player player, Damage damage)
	{
		player.ResetHealth();
		double hpBefore = player.HealthPoints;

		Console.WriteLine($"Player {player.Name} has {hpBefore:F02} HP BEFORE damage");
		Console.WriteLine($"Exposing Player {player.Name} to Damage {damage}");

		player.ReceiveDamage(damage);
		double hpAfter = player.HealthPoints;

		Console.WriteLine($"Player {player.Name} has {hpAfter:F02} HP AFTER damage");
		Console.WriteLine($"Player {player.Name} received a total of {(hpBefore - hpAfter):F02} HP damage");
		Console.WriteLine();
	}

	/// <summary>
	/// Giver en oversigt over den faktor Damage bliver til reduceret til, som funktion
	/// af resistance (fra 10 til 200). 
	/// </summary>
	public static void DamageFactorCalculation()
	{
		Console.WriteLine("Testing DamageFactorCalculation...");
		Console.WriteLine(string.Join("\n",
			Enumerable.Range(1, 20)
				.Select(r => r * 10)
				.Select(r => $"Resistance {r} -> {Player.ResistanceToDamageFactor(r):F02} ")));
		Console.WriteLine();
	}

	public static void ArmorResistance(ArmorRepository armorRepo)
	{
		Console.WriteLine("Testing ArmorResistance...");
		Console.WriteLine(string.Join("\n", 
			armorRepo
				.GetAll()
				.Select(a => $"[{a.Id}] {a.Description} : {string.Join(", ", Helpers.DamageTypeList.Select(dt => $"{dt} -> {a.GetResistance(dt)}"))}" )));
		Console.WriteLine();
	}
}
