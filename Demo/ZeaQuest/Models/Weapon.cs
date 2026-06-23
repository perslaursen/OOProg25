using ZeaQuest.Models.Base;
using ZeaQuest.Models.Damage;

namespace ZeaQuest.Models;

/// <summary>
/// Represents a Weapon, typically used by a Hero. A Weapon has:
/// 1) A Name
/// 2) A DamageSpecification
/// </summary>
public class Weapon : HasIdAndName
{
	public DamageSpecification Damage { get; }

	public Weapon(string name, DamageSpecification damageSpec)
		: base(name)
	{
		Damage = damageSpec;
	}

	public DamageDealt DealDamage()
	{
		return Damage.DealDamage();
	}
}
