// FindWindow WinAPI - функція з бібліотеки WinAPI (C++), яка знаходить вікно за його класом або назвою

using System;
using System.Runtime.InteropServices; // Простір імен для P/Invoke

class Program
{
    // Функція для пошуку вікна за класом і заголовком
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr FindWindow(string lpClassName, string? lpWindowName);
    // lpClassName - ім'я класу вікна (може бути null)
    // lpWindowName - заголовок вікна (може бути null)

    // Функція для надсилання повідомлення у вікно
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    // hWnd - дескриптор вікна
    // Msg - повідомлення, яке потрібно надіслати
    // wParam, lParam - додаткові параметри повідомлення


    // Константа для закриття вікна, описана в WinUser.h, ми описали її тут для зручності
    private const uint WM_CLOSE = 0x0010;

    // Встановлення тексту вікна
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern bool SetWindowText(IntPtr hWnd, string lpString);


    static void Main()
    {
        // Знайти вікно за класом вікна або заголовком
       // IntPtr hWnd = FindWindow(null, "Калькулятор"); // Замість "Untitled - Notepad" вкажіть назву вашого вікна
        IntPtr hWnd = FindWindow("Notepad", null); // "Notepad"  - клас вікна
        if (hWnd != IntPtr.Zero)
        {
            SetWindowText(hWnd, "Новий заголовок вікна");
            Console.WriteLine("Вікно знайдено. Закриваємо його...");
            System.Threading.Thread.Sleep(10000); // Зачекати 2 секунди, щоб побачити зміну заголовка
            Console.WriteLine("Закриваємо його...");
            System.Threading.Thread.Sleep(2000); // Зачекати 2 секунди, щоб побачити зміну заголовка
            
            // Надіслати повідомлення для закриття вікна
            SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
        else
        {
            Console.WriteLine("Вікно не знайдено.");
        }
    }
}