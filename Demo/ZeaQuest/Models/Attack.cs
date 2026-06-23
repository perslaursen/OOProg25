using ZeaQuest.Models.Base;
using ZeaQuest.Models.Damage;

namespace ZeaQuest.Models;

/// <summary>
/// Represents an Attack, e.g. performed by a Beast, An Attack has:
/// 1) A Name
/// 2) A DamageSpecification
/// </summary>
public class Attack : HasIdAndName
{
	public DamageSpecification Damage { get; }

	public Attack(string name, DamageSpecification damage)
		: base(name)
	{
		Damage = damage;
	}

	public DamageDealt DealDamage()
	{
		return Damage.DealDamage();
	}
}
