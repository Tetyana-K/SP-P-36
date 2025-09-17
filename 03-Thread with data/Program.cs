

// ParameterizedThreadStart - делегат, який дозволяє передавати параметр у потік,  delegate void ParameterizedThreadStart(object? obj)
ParameterizedThreadStart threadStart = new ParameterizedThreadStart(PrintLetters);
// створення нового потоку (#1), який виконує метод PrintLetters (великі букви)
Thread thread = new Thread(threadStart);
// запуск потоку, метод PrintLetters почне виконуватись паралельно з основним потоком
thread.Start('O'); // Передаємо 'O' як параметр

// або скорочено можна написати так
//Thread thread = new Thread(PrintLetters);
//thread.Start('Z'); // Передаємо 'Z' як параметр

int left = 1, right = 50;
// створення нового потоку (#2), який виконує анонімний метод (лямбда-вираз)
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

// створення нового потоку (#3), який виконує метод PrintSmallLetters з параметрами
Thread thread3 = new Thread(() => PrintSmallLetters('a', 'z'));
thread3.Start();

//thread.Join(); // основний потік чекатиме завершення thread (потоку 1 з великими буквами)
//thread2.Join(); // основний потік чекатиме завершення thread2 (потоку 2 з числами)

// основний потік = Main thread
for (int i = 0; i < 35; i++)
{
    
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Hello in main");
        Console.ResetColor();
    
    Thread.Sleep(100); // Затримка для наочності
}
// при роботі програмии з потоками порядок виведення може бути різним при кожному запуску, кольори допомагають відрізнити потоки, але можуть змішуватися

// функція, яка приймає параметр типу object
//   'end' — це параметр, який передається у потік під час виклику thread.Start('Z')
// тип object використовується, бо ParameterizedThreadStart дозволяє передавати лише ОДИН параметр типу object
// у цьому методі ми перетворюємо його на char: (char)end, бо приходить символ, запакований як object
void PrintLetters(object end)
{
    for (char c = 'A'; c <= (char)end; c++) // перетворення object на char, бо ми передали 'Z' (розпаковка символа, переданого у end)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\t\t{c} in thread 1");
        Thread.Sleep(100); // Затримка для наочності
        Console.ResetColor();
    }
}

// функція, яка приймає два параметри типу char
void PrintSmallLetters(char start, char end)
{
    for (char i = char.ToLower(start); i <= char.ToLower(end); i++)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\t\t\t\t\t\t{i} in thread 3");
        Console.ResetColor();
        Thread.Sleep(100); // Затримка для наочності
    }
}