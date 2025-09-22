using System;
using System.Threading;

Semaphore semaphore = new Semaphore(1, 3); // спочатку 1 дозвіл, максимум 3

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Дозволів на старті: 1");

semaphore.Release(); // +1 дозвіл
Console.WriteLine("Після Release(): дозволів стало більше");

semaphore.Release(1); // +1 дозволи
Console.WriteLine("Тепер дозволів максимум (3)");

try
{
    semaphore.Release(2); // +2 дозволи - виняток, якщо більше дозволів, ніж максимум
}
catch (SemaphoreFullException ex)
{
    Console.WriteLine($"Виняток: {ex.Message}");
}


