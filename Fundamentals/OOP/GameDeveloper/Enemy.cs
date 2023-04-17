class Enemy
{
    public string Name;
    public int Health;
    public List<Attack> AttackList;

    public Enemy(string n)
    {
        Name = n;
        Health = 100;
        AttackList = new List<Attack>();
    }

    public virtual void RandomAttack(Enemy Target)
    {
        Random random = new Random();
        int attackIdx = random.Next(AttackList.Count);
        Attack attack = AttackList[attackIdx];
        Target.Health -= attack.DamageAmount;
        Console.WriteLine($"{Name} performs {attack.Name} and deals {attack.DamageAmount} damage.");
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.Health -= ChosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {Target.Name} with {ChosenAttack.Name} dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    }


}
