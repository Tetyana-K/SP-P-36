
string[] fruits = { "Apple", "Banana", "Orange", "Mango", "Grapes" };
//foreach (var fruit in fruits) // Звичайний foreach обробляє елементи послідовно в одному потоці.
//{
//    Console.WriteLine($"[Main Thread] Processing '{fruit}'");
//    Console.WriteLine($"\t\tWord '{fruit}' has {fruit.Length} letters");
//}

Console.WriteLine("Processing fruits in parallel:\n");

Parallel.ForEach(fruits, fruit => // Parallel.ForEach бере кожен елемент масиву й обробляє його паралельно в різних потоках.
{
    Console.WriteLine($"[{Task.CurrentId}] Processing '{fruit}'"); // Task.CurrentId повертає ідентифікатор поточної таски (потоку).
    Console.WriteLine($"\t\tWord '{fruit}' has {fruit.Length} letters");
});

Console.WriteLine();

int[] arr = new int[] { 1, 10, 3, 4, 5 };
long[] results = new long[arr.Length];
Parallel.ForEach(arr, (num, state, index) =>
{
    results[index] = Square(num);
    Console.WriteLine($"Square({num}) = {results[index]}");
});


foreach (var item in results)
{
    Console.WriteLine("\t\t"+ item);
}
Console.WriteLine("\nDone!");

long Square(int x) => x * x;    
