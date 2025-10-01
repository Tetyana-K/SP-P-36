using System.Collections.Concurrent;
using System.Security.Cryptography;

/*   ConcurrentBag<T> =  колекція, яка дозволяє зберігати елементи в довільному порядку і забезпечує потокобезпечний доступ до них.
     Це колекція “bag” (мішок), яка дозволяє паралельний доступ без блокувань.
     Порядок елементів не гарантується.
     Може використовуватись як склад для тимчасових об’єктів, кеш, або збір необроблених завдань.
     На відміну від ConcurrentQueue (FIFO) і ConcurrentStack (LIFO), ConcurrentBag просто зберігає елементи 
    і роздає їх будь-яким потоком, без певного порядку.

Методи
Add(item)	Додає елемент у колекцію
TryTake(out item)	Витягує елемент (повертає false, якщо порожньо)
TryPeek(out item)	Показує елемент, не видаляючи його
IsEmpty	Перевіряє, чи порожня колекція
*/

ConcurrentBag<int> bag = new ConcurrentBag<int>();
Random rnd = new Random();

Task[] producers = new Task[3];
for (int i = 0; i < producers.Length; i++)
{
    int id = i + 1; // Локальна копія для замикання в лямбді потрібна, бо інакше всі завдання отримають останнє значення i
    producers[i] = Task.Run(() => Producer(id));

}

Task[] consumers = new Task[3];
for (int i = 0; i < consumers.Length; i++)
{
    int id = i + 1;
    consumers[i] = Task.Run(() => Consumer(id));
}

await Task.WhenAll(producers);
// Після завершення виробників, даємо споживачам трохи часу на обробку
await Task.Delay(2000);
Console.WriteLine("Main finished.");
void Producer(int id)
{
    for (int i = 0; i < 5; i++)
    {
        int item = rnd.Next(1, 100);
        bag.Add(item);
        Console.WriteLine($"Producer {id} added {item}");
        Task.Delay(rnd.Next(100, 300)).Wait(); // затримка
    }
}

void Consumer(int id)
{
    while (true)
    {
        if (bag.TryTake(out int item)) // намагаємося витягти елемент
        {
            Console.WriteLine($"\tConsumer {id} processed {item}");
            Task.Delay(rnd.Next(100, 300)).Wait(); // затримка
        }
        else
        {
            // Якщо немає елементів, спимо трохи
            Task.Delay(100).Wait();
        }
    }
}