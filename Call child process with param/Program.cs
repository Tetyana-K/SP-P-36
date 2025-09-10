using System.Diagnostics;

Console.WriteLine("Run child process and pass params");

string childPath = @"C:\Users\Ryzen\source\repos\SP P-36\ChildProcess-Hello\bin\Debug\net8.0\ChildProcess-Hello.exe";

// Параметри командного рядкаб які ми хочемо передати дочірньому процесу
string arguments = "Hello everybody! 123";

// Налаштовуємо процес
ProcessStartInfo startInfo = new ProcessStartInfo
{
    FileName = childPath,
    Arguments = arguments, // передаємо параметри
   // UseShellExecute = false,  // потрібен для перенаправлення потоків, якщо потрібно
   RedirectStandardOutput = true // перенаправляємо стандартний вивід, якщо потрібно
};

Process child = new Process { StartInfo = startInfo };

// Запускаємо дочірній процес
child.Start();

// читаємо вивід дочірнього процесу
string output = child.StandardOutput.ReadToEnd();
Console.WriteLine("Вивід дочірнього процесу:");
Console.WriteLine(output);

child.WaitForExit();
Console.WriteLine($"Дочірній процес завершився з кодом {child.ExitCode}");