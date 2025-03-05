using System;

class Program
{
    public static void Main()
    {
        int[] arr = { 3, 2, 4, -1 };
        int k = 2;
        int[] sum = new int[arr.Length];

        for (int r = 1; r <= k; r++)
        {
            int[] rotated = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                rotated[(i + 1) % arr.Length] = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                sum[i] += rotated[i];
            }

            arr = rotated;
        }

        Console.WriteLine("Sum: " + string.Join(", ", sum));
    }
}
