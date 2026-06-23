
ArmorRepository armorRepo = new ArmorRepository();
DamageRepository damageRepo = new DamageRepository();

Console.WriteLine(armorRepo);
Console.WriteLine(damageRepo);

//Test.DamageFactorCalculation();

// Tester GetResistance-metoden i Armor-klassen
Test.ArmorResistance(armorRepo);

// Tester AddArmor og GetResistance i Player-klassen
Player per = new Player("Per", 100);
per.AddArmor(armorRepo.Read(1));
per.AddArmor(armorRepo.Read(2));
//per.AddArmor(armorRepo.Read(4));
Console.WriteLine(per);

// Tester CalculateResultingDamage i Player-klassen
// Første test skal give 10,06 HP i resulterende damage
// Anden test skal give 13,04 HP i resulterende damage
Test.ExposePlayerToDamage(per, damageRepo.Read(1));
Test.ExposePlayerToDamage(per, damageRepo.Read(2));
