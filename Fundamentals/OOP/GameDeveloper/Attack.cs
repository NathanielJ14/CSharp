class Attack 
{
    public string Name;
    public int DamageAmount;

    public Attack(string n, int d)
    {
        Name = n;
        if (d < 5)
        {
            DamageAmount = 5;
        }
        else if (d > 25)
        {
            DamageAmount = 25;
        }
        else
        {
            DamageAmount = d;
        }
        
    }
}
