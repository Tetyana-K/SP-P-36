
//Thread thread = new Thread(PrintLetters);
//thread.Start('Z'); // Передаємо 'Z' як параметр

ParameterizedThreadStart threadStart = new ParameterizedThreadStart(PrintLetters);
Thread thread = new Thread(threadStart);
thread.Start('Z'); // Передаємо 'Z' як параметр

object obj = new object();
int left = 1, right = 50;
Thread thread2 = new Thread(() =>
{
    for (int i = left; i < right; i++)
    {
    
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\t\t{i} in thread 2");
            Console.ResetColor();
        
        Thread.Sleep(100); // Затримка для наочності
    }
});
thread2.Start();

Thread thread3 = new Thread(() => PrintSmallLetters('a', 'z'));
thread3.Start();

for (int i = 0; i < 35; i++)
{
    
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Hello in main");
        Console.ResetColor();
    
    Thread.Sleep(100); // Затримка для наочності
}

void PrintLetters(object end)
{
    for (char c = 'A'; c <= (char)end; c++)
    {
        Console.WriteLine($"\t\t{c} in thread");
        Thread.Sleep(100); // Затримка для наочності
    }
}

void PrintSmallLetters(char start, char end)
{
    for (char i = char.ToLower(start); i <= char.ToLower(end); i++)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\t\t\t\t\t\t{i} in thread 3");
        Console.ResetColor();
        Thread.Sleep(100); // Затримка для наочності
    }
}