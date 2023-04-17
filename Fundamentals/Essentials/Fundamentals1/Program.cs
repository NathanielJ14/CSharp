// See https://aka.ms/new-console-template for more information
// first

for(int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

//second

Random rand = new Random();
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine(rand.Next(10, 21));
}

//third

int sum = 0;

for(int i = 1; i <= 5; i++)
{
    int randomNum = rand.Next(10, 21);
    sum += randomNum;
    
}
System.Console.WriteLine(sum);

//fourth

for (int i = 1; i <= 100; i++) 
{
    if (i % 3 == 0 && i % 5 == 0) 
    {
        continue;
    } else if (i % 3 == 0 || i % 5 == 0) 
    {
        Console.WriteLine(i);
    }
}

//fifth and six

for (int i = 1; i <= 100; i++) 
{
    if (i % 3 == 0 && i % 5 == 0) 
    {
        System.Console.WriteLine("FizzBuzz");
    } else if (i % 3 == 0) 
    {
        Console.WriteLine("Fizz");
    } else if (i % 5 == 0)
    {
        System.Console.WriteLine("Buzz");
    }
}