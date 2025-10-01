
/* Підрахуйте суму всіх додатних чисел, максимум, мінімум. Для вирішення завдання
використовуйте можливості PLINQ.
*/

int[] arr = new int[] { 1, -10, 3, 4, 5 };

var query = from num in arr.AsParallel()
            where num > 0
            select num;
int sum = query.Sum();
int max = query.Max();
int min = query.Min();

Console.WriteLine($"Sum = {sum}, Max = {max}, Min = {min}");