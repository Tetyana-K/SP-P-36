// приклад демонструє використання потоком додаткових змінних
class Program
{
    static char start= 'L'; //start і end — статичні змінні класу, тому доступні всередині потоку без передачі параметрів.
    static char end = 'S';
    static void Main()
    {
        Thread thread = new Thread(PrintLetters);
        start = 'B';
        end = 'X';
        thread.Start();

        for (int i = 0; i < 35; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello in main");
            Console.ResetColor();
            Thread.Sleep(70); // Затримка для наочності
        }
    }
    static void PrintLetters()
    {
        for (char c = start; c <= end; c++)
        {
            Console.WriteLine("\t\t"+c);
            Thread.Sleep(100); // Затримка для наочності
        }
    }
}