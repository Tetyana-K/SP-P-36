using System;
using System.Collections.Concurrent;
using System.Threading;

class Program
{
    static ConcurrentQueue<int> queue = new ConcurrentQueue<int>(); // Потокобезпечна черга використовується для зберігання цілих чисел, які будуть додаватися виробником і оброблятися споживачами.
    // Вона дозволяє одночасний доступ з кількох потоків без необхідності додаткової синхронізації.
    // Це забезпечує безпечне додавання та видалення елементів з черги в багатопотоковому середовищі.

    static Random rand = new Random();

    static void Main()
    {
        // Створюємо виробника
        Thread producer = new Thread(() =>
        {
            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i); // Додає елемент у кінець потокобезпечної черги
                Console.WriteLine($"Producer added: {i}");
                Thread.Sleep(rand.Next(100, 300));
            }
        });

        // Створюємо два споживача
        Thread consumer1 = new Thread(() => ConsumeQueue(1));
        Thread consumer2 = new Thread(() => ConsumeQueue(2));

        producer.Start();
        consumer1.Start();
        consumer2.Start();

        producer.Join();
        consumer1.Join();
        consumer2.Join();

        Console.WriteLine("All done!");
    }

    static void ConsumeQueue(int id)
    {
        while (!queue.IsEmpty)
        {
            if (queue.TryDequeue(out int item)) // намагаємося видалити елемент з початку черги
            {
                Console.WriteLine($"\tConsumer {id} processed: {item}");
                Thread.Sleep(rand.Next(200, 400));
            }
        }
    }
}
/*
 Виробник додає числа 1–10 у чергу.
Два споживача паралельно витягують числа через TryDequeue.

Ніяких блокувань (lock) не потрібно — ConcurrentQueue  синхронізована.
*/