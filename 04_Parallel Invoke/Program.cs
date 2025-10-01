using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        long sum = 1;
       
        int factorial = 0;

        // Виконуємо три задачі паралельно
        Parallel.Invoke(
            () => {
                sum = Factorial(n);
                Console.WriteLine($"Факторіал  {n} = {sum}");
            },
            () => {
                factorial = Cube(n);
                Console.WriteLine($"Куб числа {n} = {factorial}");
            }
        );
    }

    static long Factorial(int num)
    {
        long res = 1;
        for (int i = 1; i <= num; i++)
            res *= i;
        return res;
    }

    static int Cube(int num)
    {
        return num * num * num;
    }

    static int SumDigits(int num)
    {
        int sum = 0;
        foreach (char c in num.ToString())
            sum += c - '0';
        return sum;
    }
}
