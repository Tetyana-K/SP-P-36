//Потік-виробник (producer) кладе числа у чергу. 1 2 3  ...4
//Потік-споживач  (consumer ) забирає числа з черги.   1 2 3 ...
//Якщо черга пуста -  споживач чекає (Wait).

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Queue<int> queue = new Queue<int>(); // спільна черга
    static object locker = new object();
    static Random rand = new Random();

    static void Main()
    {
        Thread producer = new Thread(Producer);
        Thread consumer = new Thread(Consumer);

        producer.Start();
        consumer.Start();

        producer.Join();
        consumer.Join();

        Console.WriteLine("Програма завершена.");
    }

    static void Producer()
    {
        for (int i = 1; i <= 10; i++) // виробляємо 10 елементів
        {
            lock (locker) // блокування для доступу до черги
            {
                queue.Enqueue(i); // кладемо елемент у чергу
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Виробник поклав: {i}");
                Console.ResetColor();
                Monitor.Pulse(locker); // БУДИМО СПОЖИВАЧА, якщо він чекає
            }
            Thread.Sleep(rand.Next(300, 800)); // імітація роботи
        }
    }

    static void Consumer()
    {
        for (int i = 1; i <= 10; i++) // споживаємо 10 елементів
        {
            int item;
            lock (locker) // блокування для доступу до черги
            {
                while (queue.Count == 0)
                {
                    Console.WriteLine("Черга пуста, споживач чекає...");
                    Monitor.Wait(locker); // ЧЕКАЄМО, ПОКИ З’ЯВИТЬСЯ ЕЛЕМЕНТ
                }
                // тепер у черзі є елемент
                item = queue.Dequeue(); // забираємо елемент з черги
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\t\tСпоживач взяв: {item}");
                Console.ResetColor();
            }
            Thread.Sleep(rand.Next(500, 1000)); // імітація обробки
        }
    }
}
