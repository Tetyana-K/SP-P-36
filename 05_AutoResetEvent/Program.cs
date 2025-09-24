// AutoResetEvent відрізняється від ManualResetEvent тим,
// що сигнал автоматично скидається після пробудження одного потоку, а не тримає сигнал для всіх.

class Program
{
   static AutoResetEvent autoEvent = new AutoResetEvent(false);
    //static ManualResetEvent autoEvent = new ManualResetEvent(false);// -- якщо ManualResetEvent, то всі споживачі отримають сигнал і можуть обробляти нескінченно одне число
    static int sharedData = 0; // спільні дані
    static Random rand = new Random();

    static int counter = 0;

    static void Main()
    {
        // Створюємо три споживача
        for (int i = 1; i <= 3; i++)
        {
            int id = i;
            new Thread(() => Consumer(id)).Start(); //швидкий запуск потоків споживачів
        }

        // Виробник генерує числа
        for (int i = 0; i < 15; i++)
        {
            sharedData = rand.Next(1, 100);
            Console.WriteLine($"\nProducer generated: {sharedData}");
            autoEvent.Set(); // сигнал для одного споживача
            Thread.Sleep(500); // невелика затримка
        }

        Console.WriteLine("\nProducer finished.");
    }
    static object lockObj = new object();
    static void Consumer(int id)
    {
        while (true)
        {
            autoEvent.WaitOne(); // чекаємо сигналу
            lock (lockObj)
            {
                Interlocked.Increment(ref counter);
                Console.WriteLine($"\t\tConsumer {id} processed: {sharedData} -- counter {counter}");
                if (counter >= 5) // ??
                    break; // завершуємо цикл після обробки 5 чисел
            }
        }
    }
}

//class Program
//{
//    static AutoResetEvent autoEvent = new AutoResetEvent(false);
//    static ManualResetEvent manualEvent = new ManualResetEvent(false);
//    static int sharedData = 0;

//    static void Main()
//    {
//        Thread consumer1 = new Thread(() => Consumer("C1"));
//        Thread consumer2 = new Thread(() => Consumer("C2"));

//        consumer1.Start();
//        consumer2.Start();

//        Thread.Sleep(500); // даємо споживачам запуститися

//        // Спробуємо AutoResetEvent
//        sharedData = 42;
//        Console.WriteLine("Producer sets AutoResetEvent");
//        autoEvent.Set(); // лише один споживач пробудиться

//        Thread.Sleep(1000);

//        // Спробуємо ManualResetEvent
//        sharedData = 99;
//        Console.WriteLine("Producer sets ManualResetEvent");
//        manualEvent.Set(); // обидва споживачі пробудяться
//    }

//    static void Consumer(string name)
//    {
//        Console.WriteLine($"{name} waiting AutoResetEvent");
//        autoEvent.WaitOne();
//        Console.WriteLine($"{name} received AutoResetEvent: {sharedData}");

//        Console.WriteLine($"{name} waiting ManualResetEvent");
//        manualEvent.WaitOne();
//        Console.WriteLine($"{name} received ManualResetEvent: {sharedData}");
//    }
//}

//class Program
//{
//    static AutoResetEvent autoEvent = new AutoResetEvent(false); // автоматичне скидання після пробудження
//    static int sharedData = 0;

//    static void Main()
//    {
//        Thread producer = new Thread(Producer);
//        Thread consumer = new Thread(Consumer);

//        consumer.Start(); // споживач чекає сигналу
//        producer.Start(); // виробник генерує числа

//        producer.Join();
//        consumer.Join();

//        Console.WriteLine("✅ All done.");
//    }

//    static void Producer()
//    {
//        Random rand = new Random();
//        for (int i = 0; i < 5; i++)
//        {
//            sharedData = rand.Next(1, 100);
//            Console.WriteLine($"Producer generated: {sharedData}");
//            autoEvent.Set(); // сигналізує споживачу, що дані готові
//            Thread.Sleep(500); // симуляція роботи
//        }
//    }

//    static void Consumer()
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            autoEvent.WaitOne(); // чекаємо сигналу від Producer
//            Console.WriteLine($"✅ Consumer received: {sharedData}");
//        }
//    }
//}
