
Console.WriteLine("Test af Game og Computer:");
Console.WriteLine();


// 3. Lav et par Game-objekter i Program.cs, og udskriv dem. 
Game g1 = new Game("FIFA 26", GameCategory.Sport, 80);
Game g2 = new Game("Satisfactory", GameCategory.Simulation, 120);
Game g3 = new Game("GTA 6", GameCategory.Shooter, 260);
Game g4 = new Game("ARC Raiders", GameCategory.Shooter, 110);
Game g5 = new Game("MEGA Tetris", GameCategory.Simulation, 750);

Console.WriteLine("Udskriv enkelte objekter");
Console.WriteLine(g1);
Console.WriteLine(g2);
Console.WriteLine(g3);
Console.WriteLine(g4);
Console.WriteLine();


// 4. Prøv – stadig i Program.cs – at indsætte alle Game-objekterne
// i en List, og udskriv efterfølgende indholdet af denne List.
// Prøv også gerne at udføre andre operationer som f.eks. opslag og sletning.

// Indsæt i List
List<Game> gameList = new List<Game>();
gameList.Add(g1);
gameList.Add(g2);
gameList.Add(g3);
gameList.Add(g4);

Console.WriteLine("Udskriv liste");
for (int i = 0; i < gameList.Count; i++)
{
	Console.WriteLine(gameList[i]);
}
Console.WriteLine();


// Opslag i List
Game? fifa26 = null;
foreach (Game game in gameList)
{
	if (game.Title == "FIFA 26")
		fifa26 = game;
}

Console.WriteLine("Fandt FIFA 26:");
Console.WriteLine(fifa26);

// Opslag i List
Game? gta7 = null;
foreach (Game game in gameList)
{
	if (game.Title == "GTA 7")
		gta7 = game;
}

Console.WriteLine("Fandt GTA 7:");
Console.WriteLine(gta7);

// Slet i List
Console.WriteLine("Udskriv liste (før slet)");
for (int i = 0; i < gameList.Count; i++)
{
	Console.WriteLine($"[{i}] {gameList[i]}");
}
Console.WriteLine();

gameList.RemoveAt(1);

Console.WriteLine("Udskriv liste (efter slet)");
for (int i = 0; i < gameList.Count; i++)
{
	Console.WriteLine($"[{i}] {gameList[i]}");
}
Console.WriteLine();


// 5.Prøv – stadig i Program.cs – i stedet at indsætte alle Game-objekterne
// i en Dictionary (vi antager at alle Game-objekter har en unik Title),
// og udskriv efterfølgende indholdet af denne Dictionary.
// Prøv også gerne at udføre andre operationer som f.eks. opslag og sletning.

// Indsæt i Dictionary
Dictionary<string, Game> gameDict = new Dictionary<string, Game>();
gameDict.Add(g1.Title, g1);
gameDict.Add(g2.Title, g2);
gameDict.Add(g3.Title, g3);
gameDict.Add(g4.Title, g4);

Console.WriteLine("Udskriv dictionary");
foreach (var elem in gameDict)
{
	Console.WriteLine(elem);
}
Console.WriteLine();


Console.WriteLine("Udskriv dictionary, kun keys");
foreach (var elem in gameDict.Keys)
{
	Console.WriteLine(elem);
}
Console.WriteLine();


Console.WriteLine("Udskriv dictionary, kun values");
foreach (var elem in gameDict.Values)
{
	Console.WriteLine(elem);
}
Console.WriteLine();

// Opslag i Dictionary
Game? fifa30 = null;
string key = "FIFA 30";
if (gameDict.ContainsKey(key))
{
	fifa30 = gameDict[key];
}

Console.WriteLine($"Fandt {key}");
Console.WriteLine(fifa30);
Console.WriteLine();

Game? stfc = null;
key = "Satisfactory";
if (gameDict.ContainsKey(key))
{
	stfc = gameDict[key];
}

Console.WriteLine($"Fandt {key}");
Console.WriteLine(stfc);
Console.WriteLine();

// Slet i Dictionary
stfc = null;
gameDict.Remove(key);
if (gameDict.ContainsKey(key))
{
	stfc = gameDict[key];
}

Console.WriteLine($"Fandt {key}");
Console.WriteLine(stfc);
Console.WriteLine();


// Test af Computer-klassen
Computer myPC = new Computer(700);

Console.WriteLine(myPC);
Console.WriteLine($"Kan installere {g1}: {myPC.CanInstall(g1)}");
Console.WriteLine($"Kan installere {g2}: {myPC.CanInstall(g2)}");
Console.WriteLine($"Kan installere {g5}: {myPC.CanInstall(g5)}");
Console.WriteLine();

Console.WriteLine($"Installerede {g1}: {myPC.Install(g1)}");
Console.WriteLine(myPC);
Console.WriteLine($"Installerede {g2}: {myPC.Install(g2)}");
Console.WriteLine(myPC);
Console.WriteLine($"Installerede {g3}: {myPC.Install(g3)}");
Console.WriteLine(myPC);
Console.WriteLine($"Installerede {g4}: {myPC.Install(g4)}");
Console.WriteLine(myPC);
Console.WriteLine();

Console.WriteLine($"GetGame for FIFA 26 : {myPC.GetGame("FIFA 26")}");
Console.WriteLine($"GetGame for FIFA 28 : {myPC.GetGame("FIFA 28")}");

foreach (GameCategory category in Helpers.GameGategoriesAsList())
{
	Console.WriteLine($"Antal Games i kategori {category}: {myPC.GetGamesCountInCategory(category)}");
}


foreach (GameCategory category in Helpers.GameGategoriesAsList())
{
	Console.WriteLine($"{category}: {Helpers.ListOfGamesToString(myPC.GetGamesInCategory(category),"  ")}");
}