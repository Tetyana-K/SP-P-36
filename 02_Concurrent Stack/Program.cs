using System.Collections.Concurrent;

ConcurrentStack<int> stack = new ConcurrentStack<int>();
Random rand = new Random();

// Виробник
Thread producer = new Thread(() =>
{
    for (int i = 1; i <= 10; i++)
    {
        stack.Push(i);
        Console.WriteLine($"Producer pushed: {i}");
        Thread.Sleep(rand.Next(100, 300));
    }
});

// Споживач
Thread consumer = new Thread(() => // does now work
{
    while (!stack.IsEmpty)
    {
        if (stack.TryPop(out int item))
        {
            Console.WriteLine($"\tConsumer popped: {item}");
            Thread.Sleep(rand.Next(200, 400));
        }
    }
});

producer.Start();
consumer.Start();

producer.Join();
consumer.Join();

Console.WriteLine("All done!");

/*
ConcurrentStack працює як стек (LIFO).
Споживач витягує останній доданий елемент через TryPop.
Також синхронізація відбувається автоматично.
 */

