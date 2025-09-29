// Приклад використання різних способів запуску завдань (Task) в C#

// Створення Task через конструктор і Start
using System.ComponentModel;

Task task1 = new Task(PrintHello); // створюємо завдання, яке виконає метод PrintHello
task1.Start(); // запускаємо завдання
 //task1.Wait(); // чекаємо завершення першого завдання, блокуючи потік


// Створення і запуск Task через Task.Run
Task task2 = Task.Run(PrintNumbers); // створюємо і запускаємо завдання, яке виконає метод PrintNumbers
//task2.Wait(); // чекаємо завершення другого завдання

// Створення і запуск Task через TaskFactory
TaskFactory taskFactory = new TaskFactory(); // створюємо фабрику завдань
Task task3 = taskFactory.StartNew(() => PrintLetters('a', 'e')); // створюємо і запускаємо завдання, яке виконає метод PrintLetters з параметрами

await Task.Run(PrintBye); // створюємо і запускаємо завдання, яке виконає метод PrintBye, чекаємо його завершення

//task1.Wait(); // чекаємо завершення першого завдання
//Task.WaitAll(task1, task2, task3); // чекаємо завершення всіх завдань

Task<int> task4 = Task.Run(() => Sum(5, 10)); // створюємо і запускаємо завдання, яке виконає метод Sum з параметрами
int result = await task4; // очікуємо завершення завдання і отримуємо результат
Console.WriteLine($"Sum = {result}");

int result2 = await Task.Run(() => Sum(20, 30)); // створюємо і запускаємо завдання, яке виконає метод Sum з параметрами, очікуємо його завершення і отримуємо результат
Console.WriteLine($"Sum (20, 30) = {result2}");
int Sum (int a, int b) => a + b; // Локальна функція для підрахунку суми двох чисел 
void PrintHello()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("\t\tHello from PrintHello method");
        Thread.Sleep(100); // Затримка для наочності
    }
}

void PrintBye()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("\t\t\tBye from PrintBye method");
        Thread.Sleep(100); // Затримка для наочності
    }
}
void PrintNumbers()
{
    for (int i = 1; i <= 20; i++)
    {
        Console.WriteLine(i);
        Thread.Sleep(100); // Затримка для наочності
    }
}

void PrintLetters(char start, char end)
{
    for (char c = start; c <= end; c++)
    {
        Console.WriteLine($"\t" + c);
        Thread.Sleep(100); // Затримка для наочності
    }
}   