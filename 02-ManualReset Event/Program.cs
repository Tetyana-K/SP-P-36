
int counter = 0;
ManualResetEvent mre = new ManualResetEvent(false); // створення події, яка спочатку не встановлена (не сигналізує)

Thread t1 = new Thread(Increment); // створення потоку, який виконує метод Increment
Thread t2 = new Thread(Increment); // створення другого потоку, який також виконує метод Increment

t1.Start(); // запуск першого потоку
t2.Start(); // запуск другого потоку

t1.Join(); // основний потік чекатиме завершення t1
t2.Join(); // основний потік чекатиме завершення t2

Console.WriteLine($"The end: counter = {counter}"); // очікуємо, що counter буде 200000
void Increment()
{
    for (int i = 0; i < 100000; i++)
    {
        
        
            // критична секція = частина коду, яка виконується лише одним потоком у якийсь момент часу
        counter++; 
        mre.Set(); // встановлюємо подію, дозволяючи іншим потокам продовжувати роботу
    }
   
}