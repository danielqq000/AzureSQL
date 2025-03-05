using System;

class Program
{
    public static void Main()
    {
        int[] original = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int[] copied = new int[original.Length];
        for (int i = 0; i < original.Length; i++)
        {
            copied[i] = original[i];
        }

        Console.WriteLine("Original Array: " + string.Join(", ", original));
        Console.WriteLine("Copied Array: " + string.Join(", ", copied));
    }
}
