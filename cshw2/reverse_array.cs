using System;

class Program
{
    public static void Main()
    {
        string input = "Hello";
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine(new string(charArray));
    }
}
