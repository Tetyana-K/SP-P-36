using System.Net.WebSockets;
// приклад демонструє використання двох потоків для обчислення суми та добутку елементів масиву
Console.Write("Input array size: ");
int size = int.Parse(Console.ReadLine());
int[] arr = Enumerable.Range(1, size).ToArray();
Console.WriteLine(String.Join(", ", arr));

int sum = 0; // Змінна для збереження суми, буде використовуватися в одному з потоків
long product = 1;
// Створюємо два потоки: один для обчислення суми, інший для обчислення добутку
Thread threadSum = new Thread(() => SumArray(arr));
Thread threadProduct = new Thread(() => ProductArray(arr));

// Запускаємо обидва потоки
threadSum.Start();
//threadSum.Join(); // Чекаємо завершення першого потоку перед запуском другого
threadProduct.Start();

// Чекаємо завершення обох потоків
threadProduct.Join();
threadSum.Join();

// Виводимо результати
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Sum = {sum}");
Console.WriteLine($"Product = {product}");
void SumArray(int[] arr)
{
    // int sum = 0; // можна через локальну змінну  зберігати  суму, але тоді й тут (у функції) виводити
    for (int i = 0; i < arr.Length; i++)
	{
		sum += arr[i];
        Console.WriteLine($"Sum + {arr[i]}");
		Thread.Sleep(100); // Затримка для наочності
    }
   // Console.WriteLine($"Sum = {sum}");
}
void ProductArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        product *= arr[i];
        Console.WriteLine($"\t\tProduct * {arr[i]}");
        Thread.Sleep(100); // Затримка для наочності
    }
    //Console.WriteLine($"Product = {product}");
}