class MeleeFighter : Enemy
{

    public MeleeFighter(string n) : base(n)
    {
        Health = 120;

        AttackList.Add(new Attack("Punch", 20));
        AttackList.Add(new Attack("Kick", 15));
        AttackList.Add(new Attack("Tackle", 25));
    }

    public void Rage(Enemy Target)
    {
        RandomAttack(Target);
        
    }

    public override void RandomAttack(Enemy Target)
    {
        Random random = new Random();
        int attackIdx = random.Next(AttackList.Count);
        Attack attack = AttackList[attackIdx];
        Target.Health -= attack.DamageAmount+10;
        Console.WriteLine($"{Name} rages and performs {attack.Name} on {Target.Name} dealing {attack.DamageAmount+10} damage.");
    }

}