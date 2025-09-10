using System.Runtime.InteropServices;

class Program
{
    [DllImport("UserFunc Project.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int sum(int a, int b);

    static void Main()
    {
        int result = sum(5, 70);
        Console.WriteLine($"Call C++ function sum(5, 70): {result}");
    }
}

