using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        int[] numbers = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        Dictionary<int, int> counts = new Dictionary<int, int>();

        foreach (int num in numbers)
        {
            if (counts.ContainsKey(num))
                counts[num]++;
            else
                counts[num] = 1;
        }

        int mostFrequentNumber = numbers[0];
        int highestCount = 0;

        foreach (var pair in counts)
        {
            if (pair.Value > highestCount)
            {
                mostFrequentNumber = pair.Key;
                highestCount = pair.Value;
            }
        }

        Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {highestCount} times).");
    }
}

