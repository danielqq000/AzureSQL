using System;

class Program
{
    public static void Main()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 4);

        Console.Write("Guess a number between 1 and 3: ");
        int guessedNumber = int.Parse(Console.ReadLine());

        if (guessedNumber < 1 || guessedNumber > 3)
        {
            Console.WriteLine("Please guess a number between 1 and 3.");
        }
        else if (guessedNumber < randomNumber)
        {
            Console.WriteLine("Too low!");
        }
        else if (guessedNumber > randomNumber)
        {
            Console.WriteLine("Too high!");
        }
        else
        {
            Console.WriteLine("Correct!");
        }
    }
}
