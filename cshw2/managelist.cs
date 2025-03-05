using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        List<string> items = new List<string>();

        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();

            if (input == "--")
            {
                items.Clear();
                Console.WriteLine("List cleared.");
            }
            else if (input.StartsWith("+"))
            {
                string item = input.Substring(2);
                items.Add(item);
            }
            else if (input.StartsWith("-"))
            {
                string item = input.Substring(2);
                items.Remove(item);
            }

            Console.WriteLine("Current List: " + string.Join(", ", items));
        }
    }
}
