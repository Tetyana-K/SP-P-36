// Monitor використовують, коли потрібно не тільки заблокувати ресурс, а й координувати роботу потоків.
// Wait() - звільняє блокування і переводить потік у стан очікування до отримання сигналу.
// Pulse() - посилає сигнал одному з потоків, які очікують на цьому об'єкті, що вони можуть продовжити роботу.
// PulseAll() - посилає сигнал усім потокам, які очікують на цьому об'єкті.
class Program
{
    static object locker = new object(); // об'єкт для використання з Monitor
    static bool ready = false; // прапорець готовності

    static void Main()
    {
        Thread worker = new Thread(Worker); // створюємо потік, який буде виконувати метод Worker
        worker.Start(); // запускаємо потік

        Thread.Sleep(2000); // імітація підготовки
        lock (locker)
        {
            ready = true;
            Monitor.Pulse(locker); // "будимо" потік, який чекає на цьому об'єкті locker
        }

        worker.Join();
        Console.WriteLine("Готово!");
    }

    static void Worker()
    {
        lock (locker)
        {
            while (!ready)
            {
                Console.WriteLine("Worker: Очікую сигнал...");
                Monitor.Wait(locker); // чекає, поки інший потік зробить Pulse
            }
            Console.WriteLine("Worker : Отримав сигнал, працюю далі...");
        }
    }
}
