
class Vehicle
{
    string Name;
    int Seats;
    string Color;
    bool Engine;
    int Miles;

    public Vehicle(string n, int s, string c, bool e)
    {
        Name = n;
        Seats = s;
        Color = c;
        Engine = e;
        Miles = 0;
    }

    public Vehicle(string n, string c)
    {
        Name = n;
        Color = c;
        Seats = 4;
        Engine = true;
        Miles = 0;
    }

    public void ShowInfo()
    {
        System.Console.WriteLine($"Name: {Name}, Color: {Color}, Seats: {Seats}, Engine: {Engine}, Miles: {Miles}");
    }

    public void Travel(int miles)
    {
        Miles += miles;
        System.Console.WriteLine($"This vehicle has gone {Miles} miles.");
    }
}



