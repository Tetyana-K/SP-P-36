using System;
using System.Diagnostics;

Console.WriteLine("Create process");
string processName = "C:\\Users\\Ryzen\\source\\repos\\SP P-36\\MyProgramWuthExitCode\\bin\\Debug\\net8.0\\MyProgramWithExitCode.exe";// "calc.exe";

try
{
    // створення нового процесу
    Process process = new Process();
    // встановлення властивості FileName для запуску процесу
    process.StartInfo.FileName = processName;

    process.Start(); // запуск процесу
    Console.WriteLine($"Process {processName} started successfully.");

    // очікування завершення процесу (блокує потік)
    process.WaitForExit();

    // виводимо код завершення процесу
    Console.WriteLine($"Process {processName} has exited with code: {process.ExitCode}");

    Process process2 = new Process();
    // встановлення властивості FileName для запуску процесу
    process2.StartInfo.FileName = "notepad.exe";

    process2.Start(); // запуск процесу
    Console.WriteLine($"\n\nProcess 2 notepad started successfully.");

    // очікування завершення процесу
    process2.WaitForExit();
    // виводимо код завершення процесу
    Console.WriteLine($"Process notepad has exited with code: {process2.ExitCode}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error starting process {processName}: {ex.Message}");
}

