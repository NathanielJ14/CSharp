Enemy SpecialAgent = new Enemy("007");
Enemy GangLeader = new Enemy("El Chapo");

Attack Sniper = new Attack("Sniper", 13);
Attack Shotgun = new Attack("Shotgun", 10);
Attack C4 = new Attack("C4", 24);

SpecialAgent.AttackList.Add(Sniper);
SpecialAgent.AttackList.Add(Shotgun);
SpecialAgent.AttackList.Add(C4);

SpecialAgent.RandomAttack(GangLeader);

//2

MeleeFighter Link = new MeleeFighter("Link");
RangedFighter Hanzo = new RangedFighter("Hanzo");
MagicCaster Harry = new MagicCaster("Harry Potter");

Link.PerformAttack(Hanzo, Link.AttackList[1]);
Link.Rage(Harry);
Hanzo.PerformAttack(Link, Hanzo.AttackList[0]);
Hanzo.Dash();
Hanzo.PerformAttack(Link, Hanzo.AttackList[0]);
Harry.PerformAttack(Link, Harry.AttackList[0]);
Harry.Heal(Hanzo);
Harry.Heal(Harry);