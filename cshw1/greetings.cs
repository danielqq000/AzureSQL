using System;

class Program
{
    public static void Main()
    {
        DateTime currentTime = DateTime.Now;

        int hour = currentTime.Hour;

        if (hour >= 5 && hour < 12)
        {
            Console.WriteLine("Good Morning");
            return;
        }

        if (hour >= 12 && hour < 18)
        {
            Console.WriteLine("Good Afternoon");
            return;
        }

        if (hour >= 18 && hour < 21)
        {
            Console.WriteLine("Good Evening");
            return;
        }

        if (hour >= 21 || hour < 5)
        {
            Console.WriteLine("Good Night");
            return;
        }
    }
}
