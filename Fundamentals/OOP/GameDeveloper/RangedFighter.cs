class RangedFighter : Enemy
{
    public int DistanceField;
    public RangedFighter(string n) : base(n)
    {
        DistanceField = 5;

        AttackList.Add(new Attack("Shoots an Arrow", 20));
        AttackList.Add(new Attack("Throwing a Knife", 15));
    }

    public void Dash()
    {
        DistanceField = 20;
        System.Console.WriteLine($"{Name} performed a dash!");
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (DistanceField >= 10)
        {
            Target.Health -= ChosenAttack.DamageAmount;
            Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
        }
        else
        {
            System.Console.WriteLine($"{Name} is to close to perform an attack.");
        }

    }

}