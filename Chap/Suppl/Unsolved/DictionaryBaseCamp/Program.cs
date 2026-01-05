
Dictionary<string, int> testScores = new Dictionary<string, int>();

testScores.Add("Allan", 73);
testScores.Add("Benji", 89);
testScores.Add("Carla", 60);

// Case 1
//Console.WriteLine($"Case 1: Element with key \"Benji\" is {testScores["Benji"]}");
Console.WriteLine();


// Case 2
//Console.WriteLine($"Case 2: Dictionary contains {testScores.Count} elements");
Console.WriteLine();

testScores["Allan"] = 78;
testScores.Add("David", 58);


// Case 3
//Console.WriteLine($"Case 3: Element with key \"Allan\" is {testScores["Allan"]}");
Console.WriteLine();


// Case 4
//Console.WriteLine($"Case 4a: An element with key \"david\" exists: {testScores.ContainsKey("david")}");
//Console.WriteLine($"Case 4b: An element with key \"David\" exists: {testScores.ContainsKey("David")}");
//Console.WriteLine($"Case 4c: An element with key \"Davíd\" exists: {testScores.ContainsKey("Davíd")}");
Console.WriteLine();


// Case 5: Add code that prints out all the elements in the Dictionary
Console.WriteLine("Case 5");


// Case 6: Add code that finds the average of the test scores, and prints the result
Console.WriteLine("Case 6");


// [DIFFICULT]
// Case 7: Add code that finds the name of the person with the highest test score, and prints the name.
// (you can assume that all test score are between 0 and 100).
Console.WriteLine("Case 7");
