//Mutex                                                 --Semaphore
//Дозволяє лише 1 потоку зайти	                        --Можна налаштувати кілька одночасних доступів
//Використовується, коли доступ має бути ексклюзивним	--Коли треба обмежити кількість одночасних доступів
//Має власника — потік, який захопив	                --Немає поняття «власника»

//
Semaphore semaphore = new Semaphore(2, 2); // 2 потоки на початку, максимум 2 потоки всередині
Console.OutputEncoding = System.Text.Encoding.UTF8;

for (int i = 1; i <= 5; i++) // створюємо 5 потоків (5 людей)
{
    int threadNumber = i;
    Thread t = new Thread(() => AccessRoom(threadNumber));
    t.Start();
}


void AccessRoom(int id)
{
    Console.WriteLine($"Потік {id} чекає на вхід...");

    semaphore.WaitOne(); // спроба зайти

    Console.WriteLine($"Потік {id} ЗАЙШОВ у кімнату.");
    Thread.Sleep(2000); // займає кімнату 2 секунди
    Console.WriteLine($"Потік {id} ВИХОДИТЬ з кімнати.");

    semaphore.Release(); // звільняє місце
}
