using System.Collections.Concurrent;

// Потокобезпечний словник для зберігання кількості відвідувань сторінок
ConcurrentDictionary<string, int> pageVisits = new ConcurrentDictionary<string, int>();

// Масив сторінок
string[] pages = { "home", "about", "contact", "products", "blog" };
Random rnd = new Random();

// Створюємо 5 паралельних завдань, які імітують відвідування сторінок
Task[] tasks = new Task[5];
for (int i = 0; i < tasks.Length; i++)
{
    int taskId = i; // копія змінної для замикання
    tasks[i] = Task.Run(() =>
    {
        SimulatePageVisits(taskId);
    });
}

Task.WaitAll(tasks);

// Виводимо результати
Console.WriteLine("\nTotal page visits:");
foreach (var kvp in pageVisits)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

void SimulatePageVisits(int taskId)
{
    for (int j = 0; j < 10; j++) // кожне завдання робить 10 відвідувань
    {
        string page = pages[rnd.Next(pages.Length)]; // випадковий вибір сторінки

        Console.WriteLine($"Task {taskId} visited page: {page}");

        // Колекція забезпечить атомарне збільшення лічильника відвідувань 
        pageVisits.AddOrUpdate(page,
                               1, // якщо ключу немає — додаємо 1
                               (key, existingVal) => existingVal + 1); // якщо є — збільшуємо на 1

        Task.Delay(rnd.Next(50, 150)).Wait(); // затримка для демонстрації паралелізму
    }
}