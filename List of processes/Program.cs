// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

/*Процес — це запущена програма (наприклад, notepad.exe, chrome.exe).
Має свій адресний простір пам’яті, ресурси ОС (файли, сокети, дескриптори).
Один процес ізольований від іншого → процеси напряму не бачать пам'ять один одного.
У процеса може бути один або багато потоків.
*/

Console.WriteLine("______________Current Process");
Process currentProcess = Process.GetCurrentProcess();
//Console.WriteLine($"Process name:\t{currentProcess.ProcessName}");
PrintProcessInfo(currentProcess);
Console.ReadKey();

currentProcess.PriorityClass = ProcessPriorityClass.High; // встановлюємо високий пріоритет для поточного процесу
PrintProcessInfo(currentProcess);
Console.ReadKey();

Console.WriteLine("______________List of processes");
while (true)
{
    var processes = Process.GetProcesses().OrderBy(p => p.ProcessName); // отримуємо список всіх процесів, впорядковуючи їх за назвою
    foreach (var process in processes)
    {
        try
        {
            // Виводимо назву процесу та його ID (PID = Process ID)

              Console.WriteLine($"Process: {process.ProcessName}\tID: {process.Id}\tMemory: {Math.Round(process.PrivateMemorySize64 / 1024.0, 2)} KB");
            //  Console.WriteLine($"Process: {process.ProcessName}\tID: {process.Id}\tMemory: {Math.Round(process.WorkingSet64 / 1024.0, 2)} KB   {Math.Round(process.PrivateMemorySize64 / 1024.0, 2)} KB");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving process information: {ex.Message}");
        }
    }
    Console.WriteLine("Press any key to refresh the list or 'q' to quit.");
    var key = Console.ReadKey(true);
    if (key.KeyChar == 'q' || key.KeyChar == 'Q')
    {
        break;
    }
    Console.Clear();
}

Console.Clear();

Console.Write("\nEnter process PID: ");
if (!int.TryParse(Console.ReadLine(), out int pid))
{
    Console.WriteLine("Invalid PID.");
    return;
}

try
{
    Process proc = Process.GetProcessById(pid);

    Console.WriteLine("\n== Detail info ==");
    Console.WriteLine($"Process name:\t{proc.ProcessName}");
    Console.WriteLine($"PID:\t{proc.Id}");

    try
    {
        Console.WriteLine($"Start time:\t{proc.StartTime}");
    }
    catch
    {
        Console.WriteLine($"Start time: dont know");
    }

    Console.WriteLine($"Total CPU time:     {proc.TotalProcessorTime}");
    Console.WriteLine($"Threads number:     {proc.Threads.Count}");

    int sameNamed = Process.GetProcessesByName(proc.ProcessName).Length;
    Console.WriteLine($"Number of copies:       {sameNamed}");
}
catch (Exception ex)
{
    Console.WriteLine($"Process with PID {pid} not found or forbidden.");
    Console.WriteLine($"Details: {ex.Message}");
}

void PrintProcessInfo(Process process)
{
    Console.WriteLine($"Process: {process.ProcessName}");
    Console.WriteLine($"ID: {process.Id}");
    Console.WriteLine($"Machine name: {process.MachineName}"); // ім'я комп'ютера, на якому запущено процес (зараз буде . = поточний комп’ютер)
    Console.WriteLine($"Main windows title: {process.MainWindowTitle}");
    Console.WriteLine($"Priority: {process.PriorityClass}");
    Console.WriteLine($"Start time: {process.StartTime}");
    
    // Включає користувацький час (User) + системний час (Kernel)
    Console.WriteLine($"Total CPU time: {process.TotalProcessorTime}");

    // Час, витрачений  на користувацький код
    Console.WriteLine($"User Processor Time: {process.UserProcessorTime}");
    Console.WriteLine($"PrivateMemorySize (KB): {process.PrivateMemorySize64 / 1024} KB");
    Console.WriteLine(new string('-', 40));
}