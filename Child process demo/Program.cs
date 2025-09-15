using System.Diagnostics;

var psi = new ProcessStartInfo("notepad.exe")
{
    UseShellExecute = false, // необхідно для перенаправлення потоків
    RedirectStandardOutput = true, // дозволяє читати стандартний вивід
    RedirectStandardError = true, // дозволяє читати стандартний потік помилок
    RedirectStandardInput = true // дозволяє писати у стандартний вхід
};

using var process = Process.Start(psi);

process?.WaitForExit(); // чекаємо, поки дочірній процес завершиться

Console.WriteLine("_________________");