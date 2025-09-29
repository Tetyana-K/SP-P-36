using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        // Запускаємо таску з параметром
        Task<int> task = Task.Run(() => CalculateSquare(7)); // створюємо таску, яка обчислює квадрат числа 7

        int result = await task; // очікуємо результат = 49
        Console.WriteLine($"Квадрат числа 7: {result}");

        int number = 5;    

        Task<int> task2 = Task.Run(() => number * number * number); // створюємо таску, яка обчислює куб числа number (5)
        int result2 = await task2; // очікуємо результат = 125
        Console.WriteLine($"Куб числа {number}: {result2}");

        // Використовуємо асинхронну функцію для обчислення степеня числа
        int baseNum = 2;
        int exponent = 8;
        int powerResult = await CalculatePowerAsync(baseNum, exponent); // очікуємо результат = 256
        Console.WriteLine($"{baseNum} ^ {exponent} = {powerResult}");

    }

    static int CalculateSquare(int number)
    {
        return number * number;
    }

    // асинхронна функцыя обчислння степеня числа
    static async Task<int> CalculatePowerAsync(int baseNum, int exponent)
    {
        return await Task.Run(() => // лямбда-вираз для обчислення степеня
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        });
    }
}
