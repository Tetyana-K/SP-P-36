
class Program
{
    static Semaphore gameHall = new Semaphore(3, 3); // максимум 3 гравці одночасно
    static object fileLock = new object(); // для синхронізації доступу до файлу
    static Random random = new Random();

    static void Main()
    {
        int totalPlayers = 10; // загальна кількість гравців
        List<Thread> threads = new List<Thread>(); // список потоків, поки пустий

        for (int i = 1; i <= totalPlayers; i++) // створюємо потоки для кожного гравця
        {
            int playerId = i; // id = 1, 2, ..., 10
            Thread t = new Thread(() => PlayGame(playerId)); // створюємо потік з лямбда-виразом, щоб передати playerId
            threads.Add(t); // додаємо потік у список
            t.Start();
        }

        foreach (var t in threads) // чекаємо, поки всі гравці завершать гру
            t.Join();

        Console.WriteLine("Гра завершена. Перевірте файл score.txt");
    }

    static void PlayGame(int playerId)
    {
        gameHall.WaitOne(); // чекаємо, поки звільниться місце

        string playerName = $"Гравець {playerId}";
        int score = 0; // початковий рахунок, локальний для кожного гравця, кожен потік має свою копію (бо кожен потік має свій стек)

        Console.WriteLine($"{playerName} зайшов у зал.");

        for (int round = 1; round <= 5; round++)
        {
            int points = random.Next(1, 11); // випадкові очки від 1 до 10
            score += points;
            Console.WriteLine($"{playerName} отримав {points} очок у раунді {round}.");
            Thread.Sleep(100); // затримка для наочності
        }

        // запис результату у файл
        lock (fileLock)
        {
            File.AppendAllText("score.txt", $"{playerName} - {score} очок\n");
        }

        Console.WriteLine($"{playerName} вийшов із залу з {score} очками.");
        gameHall.Release(); // звільняємо місце для іншого гравця
    }
}
