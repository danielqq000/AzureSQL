using System;

class Program
{
    public static void Main()
    {
        Console.Write("Enter number of centuries: ");
        if (int.TryParse(Console.ReadLine(), out int centuries))
        {
            int years = centuries * 100;
            int days = (int)(years * 365);
            long hours = days * 24L;
            long minutes = hours * 60L;
            long seconds = minutes * 60L;
            long milliseconds = seconds * 1000L;
            ulong microseconds = (ulong)milliseconds * 1000;
            ulong nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter an integer.");
        }
    }
}
