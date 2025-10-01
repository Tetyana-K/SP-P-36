
/* Підрахуйте суму всіх додатних чисел, максимум, мінімум. Для вирішення завдання
використовуйте можливості PLINQ.
*/

int[] arr = new int[] { 1, -10, 3, 4, 5, -7 };

Console.WriteLine($"Sum  = {arr.Sum()}"); // використовуємо LINQ для підрахунку суми всіх чисел
var negativeNumbers = from num in arr // LINQ-запит для вибору від'ємних чисел
                      where num < 0
                      select num;   
var evenNUmbers = arr.Where(n => n % 2 == 0); // LINQ-метод для вибору парних чисел

Console.WriteLine("Negative numbers: " + string.Join(", ", negativeNumbers));
Console.WriteLine("Even numbers: " + string.Join(", ", evenNUmbers));

Console.WriteLine("____ Parallel Linq (PLINQ)_______");
var query = from num in arr.AsParallel() // AsParallel() - перетворює колекцію в паралельну для PLINQ
            where num > 0
            select num;
int sum = query.Sum();
int max = query.Max();
int min = query.Min();

Console.WriteLine($"Sum = {sum}, Max = {max}, Min = {min}");