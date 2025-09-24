// ManualResetEvent, AutoResetEvent - це  сигнальні події (event) у багатопотоковому середовищі.
//Потоки можуть очікувати сигнал або передавати сигнал іншим потокам.
//Використовуються для координації потоків, щоб один потік чекав на завершення іншого або на певну умову.

//-----------------ManualResetEvent
//Коли викликаємо Set(), всі потоки, що чекають, розблоковуються.
//Потік не зникає після сигналу — подія залишається встановленою, поки не викличемо Reset().
//Підходить, коли кілька потоків мають чекати одну і ту ж подію

class Program
{
    static ManualResetEvent mre = new ManualResetEvent(false); // створення події, яка спочатку не встановлена (не сигналізує)

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Thread t = new Thread(Worker);
        t.Start();

        Console.WriteLine("Головний потік робить щось...");
        Thread.Sleep(2000);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Головний потік сигналізує робітнику!");
        Console.ResetColor();
        mre.Set(); // сигнал для робітника

        t.Join();
        Console.WriteLine("Програма завершена.");
    }

    static void Worker()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Робітник чекає сигнал...");
        mre.WaitOne(); // чекає сигналу
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Робітник отримав сигнал і працює далі!");
    }
}
