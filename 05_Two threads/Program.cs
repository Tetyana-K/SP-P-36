int numThreads = 2;
Thread [] threads = new Thread[numThreads];

char startLetter = 'A', endLetter = 'Z';
int size = (endLetter - startLetter + 1) / numThreads;
for (int i = 0; i < numThreads; i++)
{
    char localStart = startLetter;
    char localEnd = (char)(localStart + size);
    threads[i] = new Thread(() => PrintLetters(localStart, localEnd));
    startLetter = (char)(localEnd + 1);
}

for (int i = 0; i < numThreads; i++)
{
    threads[i].Start();
}

void PrintLetters(char start, char  end)
{
    for (char c = start; c <= end; c++)
    {
        Console.WriteLine($"\t\t{c} in thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(100); // Затримка для наочності
    }
}
