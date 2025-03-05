using System;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string sentence = "C# is not C++, and PHP is not Delphi!";
        string[] words = Regex.Split(sentence, @"(\W+)");
        Array.Reverse(words);
        Console.WriteLine(string.Join("", words));
    }
}
