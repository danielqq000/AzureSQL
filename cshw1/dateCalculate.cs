using System;

class Program
{
    public static void Main()
    {
        DateTime birthDate = new DateTime(1995, 1, 1);
        
        DateTime currentDate = DateTime.Now;
        TimeSpan ageInDays = currentDate - birthDate;
        int totalDays = (int)ageInDays.TotalDays;

        Console.WriteLine("You are {0} days old.", totalDays);

        int daysToNextAnniversary = 10000 - (totalDays % 10000);
        DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);

        Console.WriteLine("Your next 10,000-day anniversary will be on: {0:MMMM dd, yyyy}", nextAnniversary);
    }
}
