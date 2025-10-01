// Continuation Task (завдання-продовження) у .NET – це завдання, яке запускається після завершення іншого завдання.
// Тобто воно «підписується» на виконання Task і починається автоматично, коли попереднє завдання закінчилося.

Task<int> firstTask = Task.Run(() =>
{
    Console.WriteLine("First task: calculatiog something ... (42)...");
    Thread.Sleep(1000);
    return 42;
});


// Продовження, яке виконується після завершення firstTask
Task continuation = firstTask.ContinueWith(prevTask =>
{
    Console.WriteLine($"Continuation Task received result: {prevTask.Result}"); // Використовуємо результат першого завдання t.Result (42)
    Console.WriteLine($"Continuation Task received result^2: {Math.Pow(prevTask.Result,2)}"); // Використовуємо результат першого завдання t.Result (42)
});

await continuation; // Очікуємо завершення продовження

//ContinueWith дозволяє обробляти результат (t.Result) або помилки попереднього завдання.


await Task.Run(() => "\n\nHello")
    .ContinueWith(t => t.Result + " from") // t.Result - це результат попередньої таски ('Hello')  + 'from
    .ContinueWith(t => t.Result + " Continuation Task") // t.result - це результат попередньої таски ('Hello from') + ' Continuation Task'
    .ContinueWith(t => Console.WriteLine(t.Result)); // t.Result - це результат попередньої таски ('Hello from Continuation Task') і роздруковуємо його
