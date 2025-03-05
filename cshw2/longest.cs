using System;

class Program
{
    public static void Main()
    {
        int[] arr = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        int max = 0, cur = 1, val = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
                cur++;
            else
                cur = 1;

            if (cur > max)
            {
                max = cur;
                val = arr[i];
            }
        }

        Console.WriteLine("Longest Sequence: " + string.Join(" ", Enumerable.Repeat(val, max)));
    }
}
