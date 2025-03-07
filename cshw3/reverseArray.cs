using System;

class Program
{
    static int[] GenerateNumbers(int len)
    {
        int[] numbers = new int[len];
        for (int i = 0; i < len; i++)
        {
            numbers[i] = i + 1;
        }
        return numbers;
    }

    static void Reverse(int[] array)
    {
        int len = array.Length;
        for (int i = 0; i < len / 2; i++)
        {
            int temp = array[i];
            array[i] = array[len - i - 1];
            array[len - i - 1] = temp;
        }
    }

    static void PrintNumbers(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[] numbers = GenerateNumbers(10);
        Console.WriteLine("Original Array:");
        PrintNumbers(numbers);

        Reverse(numbers);
        Console.WriteLine("Reversed Array:");
        PrintNumbers(numbers);
    }
}
