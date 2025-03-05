using System;

class Program
{
    public static void Main()
    {
        string url = "https://www.apple.com/iphone";
        Uri uri = new Uri(url);

        Console.WriteLine("[protocol] = \"" + uri.Scheme + "\"");
        Console.WriteLine("[server] = \"" + uri.Host + "\"");
        Console.WriteLine("[resource] = \"" + uri.AbsolutePath.TrimStart('/') + "\"");
    }
}
