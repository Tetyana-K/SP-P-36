class Program
{
    static char start= 'L';
    static char end = 'S';
    static void Main()
    {
        Thread thread = new Thread(PrintLetters);
        thread.Start();
    }
    static void PrintLetters()
    {
        for (char c = start; c <= end; c++)
        {
            Console.Write(c);
            Thread.Sleep(100); // Затримка для наочності
        }
    }
}