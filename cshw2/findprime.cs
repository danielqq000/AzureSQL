using System;
using System.Collections.Generic;

class Program
{
    private static int[] FindPrimesInRange(int start, int end)
    {
        List<int> primes = new List<int>();

        for (int i = start; i <= end; i++)
        {
            if (IsPrime(i))
                primes.Add(i);
        }

        return primes.ToArray();
    }

    private static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0) return false;
        return true;
    }

    public static void Main()
    {
        int[] primes = FindPrimesInRange(10, 50);
        Console.WriteLine("Primes: " + string.Join(", ", primes));
    }
}
