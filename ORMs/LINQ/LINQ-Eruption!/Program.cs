List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// // // Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// // // Execute Assignment Tasks here!

IEnumerable<Eruption> firstEruptionInChile = eruptions.Where(l => l.Location == "Chile").Take(1);
PrintEach(firstEruptionInChile, "Chile eruptions.");

IEnumerable<Eruption> firstEruptionInHawaiianIs = eruptions.Where(l => l.Location == "Hawaiian Is").Take(1);
if(firstEruptionInHawaiianIs.Any())
{
    PrintEach(firstEruptionInHawaiianIs, "Hawaiian Is eruptions.");
}
else 
{
    System.Console.WriteLine("No Hawaiian Is Eruption found.");
}

IEnumerable<Eruption> firstEruptionInGreenland = eruptions.Where(l => l.Location == "Greenland").Take(1);
if(firstEruptionInGreenland.Any())
{
    PrintEach(firstEruptionInGreenland, "Greenland eruptions.");
}
else 
{
    System.Console.WriteLine("No Greenland Eruption found.");
}

IEnumerable<Eruption> firstEruptionInNewZealand = eruptions.Where(l => l.Location == "New Zealand").Where(d => d.Year > 1900).Take(1);
PrintEach(firstEruptionInNewZealand, "New Zealand eruption after 1900.");

IEnumerable<Eruption> allOver2000m = eruptions.Where(h => h.ElevationInMeters > 2000);
PrintEach(allOver2000m, "All Eruptions where volcanos elevation is over 2000m");

IEnumerable<Eruption> firstNameL = eruptions.Where(n => n.Volcano.StartsWith("L"));
PrintEach(firstNameL, "All volcanos with the first letter L in their name");

int highestElv = eruptions.Max(h => h.ElevationInMeters);
System.Console.WriteLine($"This is the highest elevation {highestElv}");

IEnumerable<Eruption> highestVolcano = eruptions.Where(h => h.ElevationInMeters == highestElv);
PrintEach(highestVolcano, "The Volcano with the highest elevation");


List<string> volcanoNames = eruptions.OrderBy(n => n.Volcano).Select(n => n.Volcano).ToList();
foreach (string name in volcanoNames)
{
    Console.WriteLine(name);
}

int sumOfElv = eruptions.Sum(e => e.ElevationInMeters);
System.Console.WriteLine($"This is the sum of all the elevations {sumOfElv}");

bool anyIn2000s = eruptions.Any(h => h.Year == 2000);
System.Console.WriteLine($"Did any volcanos erupt in the 2000: {anyIn2000s}");


IEnumerable<Eruption> stratoVolcanos = eruptions.Where(l => l.Type == "Stratovolcano").Take(3);
PrintEach(stratoVolcanos, "First 3 StratovoVolcanos.");

IEnumerable<Eruption> eruptionsBefore1000 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(eruptionsBefore1000, "Eruptions before the year 1000 CE alphabetically by volcano name.");


List<string> eruptionsBefore1000Mod = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(n => n.Volcano).ToList();
foreach (string name in eruptionsBefore1000Mod)
{
    Console.WriteLine(name);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
