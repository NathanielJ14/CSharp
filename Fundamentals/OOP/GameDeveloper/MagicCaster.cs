class MagicCaster : Enemy
{

    public MagicCaster(string n) : base(n)
    {
        Health = 80;

        AttackList.Add(new Attack("Fireball", 25));
        AttackList.Add(new Attack("Lighting Bolt", 20));
        AttackList.Add(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy Target)
    {
        Target.Health += 40;
        System.Console.WriteLine($"{Name} heals {Target.Name} for 40. {Target.Name}'s new health is {Target.Health}");
    }

    
}