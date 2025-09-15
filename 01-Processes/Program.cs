using System;
using System.Diagnostics;

Process.Start("notepad"); // запускає Notepad
Console.WriteLine("We have started Notepad");

Process.Start("calc"); // запускає калькулятор

//Process.Start(new ProcessStartInfo
//{
//    FileName = "https://msdn.com",
////    FileName = "https://google.com", // відкриває URL у браузері за замовчуванням у новій вкладці
//    UseShellExecute = true   // важливо для відкриття URL у браузері
//});

//Process.Start(new ProcessStartInfo
//{

//   FileName = "chrome.exe",
//   // Arguments = "--new-window https://msdn.com", // відкриває нове вікно, а не вкладку
//    UseShellExecute = true   // важливо для відкриття URL у браузері
//});


Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "www.msdn.com");

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

