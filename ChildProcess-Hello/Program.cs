//class Program
{
  //  static void Main(string[] args)
    {
        Console.WriteLine("Дочірній процес отримав параметри:");

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"Аргумент {i}: {args[i]}");
        }

        Console.WriteLine("Натисніть Enter для завершення...");
        Console.ReadLine();
    }
}
