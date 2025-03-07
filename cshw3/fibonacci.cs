using System;

class FibonacciProgram
{
    static int Fibonacci(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("First 10 Fibonacci Numbers:");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
        Console.WriteLine();
    }
}
