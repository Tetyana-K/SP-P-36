using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // Знайдемо процеси Notepad
        Process[] processes = Process.GetProcessesByName("notepad");

        if (processes.Length == 0)
        {
            Console.WriteLine("Не знайдено процесу Notepad.");
            return;
        }

        foreach (var proc in processes)
        {
            Console.WriteLine($"Спроба закрити процес: {proc.ProcessName}, PID: {proc.Id}");

            // 1. М'яке закриття (Close)
            if (proc.CloseMainWindow())
            {
                // Чекаємо максимум 5 секунд, поки процес завершиться
                if (proc.WaitForExit(5000))
                {
                    Console.WriteLine("Процес успішно закрито (Close).");
                    continue;
                }
            }

            // 2. Якщо процес не закрився – примусове завершення (Kill)
            Console.WriteLine("Процес не відповідав. Виконуємо Kill...");
            try
            {
                proc.Kill();
                proc.WaitForExit();
                Console.WriteLine("Процес завершено примусово (Kill).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завершенні процесу: {ex.Message}");
            }
        }
    }
}
