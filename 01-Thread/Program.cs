Thread thread = new Thread(PrintLetters);
thread.Start();
for (int i = 0; i < 100; i++)
{
    Console.WriteLine("Hello in main");
    Thread.Sleep(100); // Затримка для наочності

}
void PrintLetters()
{
    for (char c = 'A'; c <= 'Z'; c++)
    {
        Console.WriteLine($"\t\t{c} in thread");
        Thread.Sleep(100); // Затримка для наочності
    }
}   