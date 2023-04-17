//Coin Flip

static void CoinFlip()
{
    int temp = 0;
    Random rand = new Random();
    temp += rand.Next(1,3);
    if (temp == 1)
    {
        System.Console.WriteLine("Heads");
    }
    else
    {
        System.Console.WriteLine("Tails");
    }
}

CoinFlip();


//Dice Roll

static int RollDice()
{
    int[] numArray = {1,2,3,4,5,6};

    int temp = 0;
    Random rand = new Random();
    temp += rand.Next(0,6);
    int roll = numArray[temp];
    return roll;
}

// RollDice();


//Stat Roll

static void RollFour()
{
    List<int> rolls = new List<int>();
    rolls.Add(RollDice());
    rolls.Add(RollDice());
    rolls.Add(RollDice());
    rolls.Add(RollDice());
    
    foreach (int r in rolls)
    {
        System.Console.WriteLine(r);
    }

}

// RollFour();


//Roll Until 

static void RollUntil(int yourNum)
{
    int temp = 0;
    int count = 0;
    for (int i = 1; temp != yourNum; i++ )
    {
        temp = RollDice();
        count = i;
    }

    System.Console.WriteLine($"It took {count} times to roll a {temp}");
}

RollUntil(4);