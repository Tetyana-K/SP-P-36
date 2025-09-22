using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Початок завдання");
        LongOperation(); // тривала операція
        Console.WriteLine("Завдання завершено");
    }

    static void LongOperation()
    {
        Console.WriteLine("Старт завантаження...");
        Thread.Sleep(3000); // імітація довгої роботи
        Console.WriteLine("Завершено завантаження!");
    }
}
