using System;
using System.Collections.Generic;

class Program
{
    private static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (word[left] != word[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    public static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string text = Console.ReadLine();

        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> palindromes = new List<string>();

        foreach (string word in words)
        {
            if (IsPalindrome(word) && !palindromes.Contains(word))
            {
                palindromes.Add(word);
            }
        }

        palindromes.Sort();
        Console.WriteLine("Palindromes found: " + string.Join(", ", palindromes));
    }

}
