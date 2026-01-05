
using System.Diagnostics;

KundeKartotekTest testList = new KundeKartotekTest(new KundeKartotekList());
KundeKartotekTest testDict = new KundeKartotekTest(new KundeKartotekDictionary());

int n = 100;
int k = 100000;


Console.WriteLine("StressTest Dict");
long msDict = testDict.StressTest(n, k);
Console.WriteLine($"StressTest Dict - DONE {msDict}");



Console.WriteLine("StressTest List");
long msList = testList.StressTest(n, k);
Console.WriteLine($"StressTest List - DONE {msList}");



