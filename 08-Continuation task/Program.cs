// Continuation Task (завдання-продовження) у .NET – це завдання, яке запускається після завершення іншого завдання.
// Тобто воно «підписується» на виконання Task і починається автоматично, коли попереднє завдання закінчилося.
Task<int> firstTask = Task.Run(() =>
{
    Console.WriteLine("First task: calculatiog something ... (42)...");
    Thread.Sleep(1000);
    return 42;
});


// Продовження, яке виконується після завершення firstTask
Task continuation = firstTask.ContinueWith(t =>
{
    Console.WriteLine($"Continuation Task received result: {t.Result}"); // Використовуємо результат першого завдання t.Result (42)
});
await continuation; // Очікуємо завершення продовження

//ContinueWith дозволяє обробляти результат (t.Result) або помилки попереднього завдання.


await Task.Run(() => "\n\nHello")
    .ContinueWith(t => t.Result + " from")
    .ContinueWith(t => t.Result + " Continuation Task")
    .ContinueWith(t => Console.WriteLine(t.Result));
