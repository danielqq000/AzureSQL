using System;

class Program
{
    public static void Main()
    {
        string input = "Hello";
        for (int i = input.Length - 1; i >= 0; i--)
            Console.Write(input[i]);
    }
}
