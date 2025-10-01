// Parallel.For
//Цей метод дозволяє виконувати цикл for паралельно, тобто ітерації виконуються одночасно у кількох потоках.

// Приклад використання Parallel.For для обчислення квадратів чисел у масиві.
// Обчислення виконується паралельно, що може значно прискорити процес для великих масивів.
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] numbers = new int[150]; // масив для збереження результатів (квадратів чисел)

        //for (int i = 0; i < numbers.Length; i++)// послідовний цикл for для ініціалізації масиву
        //{
        //    numbers[i] = i * i; // ініціалізація масиву нулями
        //    Console.WriteLine(numbers[i]);
        //}

        //// Паралельний цикл for для обчислення квадратів чисел від 0 до 99, буде виконуватися у кількох потоках
        //Parallel.For(0, numbers.Length, i =>
        //{
        //    numbers[i] = i * i; // обчислення квадратів
        //    Console.WriteLine($"Thread {Task.CurrentId} computed numbers[{i}] = {numbers[i]}"); // виведення інформації про потік і результат
        //    //Thread.Sleep(100); // імітація тривалої операції
        //});

        Console.WriteLine("All tasks completed.");

        Stopwatch sw = Stopwatch.StartNew();
        //sw2.Reset();
       // sw.Start();
        SaveAndPrintNumbers(numbers); // послідовне збереження і виведення
        sw.Stop();
        Console.WriteLine($"\t\tTraditional ::::: {sw.ElapsedMilliseconds} miliseconds");
        Console.ReadKey();

        Stopwatch sw2 = Stopwatch.StartNew();
        SaveAndPrintNumbersParallel(numbers); // паралельне збереження і виведення
        sw2.Stop();
        Console.WriteLine($"\t\tParalel :::: {sw2.ElapsedMilliseconds} miliseconds");

    }

    static void SaveAndPrintNumbers(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i * i; 
            //Console.WriteLine($"{i} -> {arr[i]}");
            Console.WriteLine($"Thread {Task.CurrentId} computed numbers[{i}] : {arr[i]}");

            //Thread.Sleep(50); // Затримка для наочності
        }
    }

    static void SaveAndPrintNumbersParallel(int[] arr)
    {
        Parallel.For(0, arr.Length, i =>
        {
            arr[i] = i*i;
            //Console.WriteLine(arr[i]);

            Console.WriteLine($"Thread {Task.CurrentId} computed numbers[{i}] = {arr[i]}");

        });
    }
}
/*
Паралельність: цикл розбивається на частини і виконується в пулі потоків.
Немає гарантованого порядку: порядок виконання ітерацій не визначений.
Оптимально для CPU-bound задач: обчислення, трансформації, великі масиви.

**** Пул потоків - це набір потоків, які використовуються для виконання завдань.
**** Використання пулу потоків дозволяє ефективно керувати ресурсами системи.
*/