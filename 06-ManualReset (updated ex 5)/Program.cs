using System;
using System.Threading;

class Program
{
    static AutoResetEvent autoEvent = new AutoResetEvent(false);
    static int sharedData = 0;
    static Random rand = new Random();
    static int numbersToGenerate = 5;
    static int numbersProcessed = 0;
    static readonly object locker = new object();

    static void Main()
    {
        // Створюємо три споживача
        for (int i = 1; i <= 3; i++)
        {
            int id = i;
            new Thread(() => Consumer(id)).Start();
        }

        // Виробник генерує числа
        for (int i = 0; i < numbersToGenerate; i++)
        {
            sharedData = rand.Next(1, 100);
            Console.WriteLine($"\nProducer generated: {sharedData}");
            autoEvent.Set(); // сигнал для одного споживача
            Thread.Sleep(500);
        }

        // Чекаємо, поки всі числа будуть оброблені
        while (true)
        {
            lock (locker)
            {
                if (numbersProcessed >= numbersToGenerate)
                    break;
            }
            Thread.Sleep(100);
        }

        Console.WriteLine("\nProducer finished. Press Enter to exit.");
        Console.ReadLine();
    }

    static void Consumer(int id)
    {
        while (true)
        {
            autoEvent.WaitOne(); // чекаємо сигналу

            lock (locker)
            {
                if (numbersProcessed >= numbersToGenerate)
                    break; // завершуємо цикл
                numbersProcessed++;
            }

            Console.WriteLine($"\t\tConsumer {id} processed: {sharedData}");
        }
    }
}
