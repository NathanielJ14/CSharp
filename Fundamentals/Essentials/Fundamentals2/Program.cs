//three basic arrays
int[] numArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

string[] names = new string[] { "Tim", "Martin", "Nikki", "Sara" };

bool[] booleanArr = new bool[10];

//List of Flavors
List<string> flavors = new List<string>();

flavors.Add("Chocolate");
flavors.Add("Vanilla");
flavors.Add("Mint");
flavors.Add("Coffee");
flavors.Add("Strawberry");

System.Console.WriteLine($"There are currently {flavors.Count} ice cream flavors.");

System.Console.WriteLine($"The third flavor is {flavors[2]}.");

flavors.RemoveAt(2);

//User Dictionary
Dictionary<string, string> user = new Dictionary<string, string>();
Random random = new Random();

foreach (string n in names)
{
    int index = random.Next(flavors.Count);
    string randomFlavor = flavors[index];
    user.Add(n, randomFlavor);
}

foreach (KeyValuePair<string, string> name in user)
{
    Console.WriteLine($"{name.Key}: {name.Value}");
}

