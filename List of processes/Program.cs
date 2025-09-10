// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("List of processes");
while (true)
{
    var processes = Process.GetProcesses().OrderBy(p => p.ProcessName); // отримуємо список всіх процесів, впорядковуючи їх за назвою
    foreach (var process in processes)
    {
        try
        {
            // Виводимо назву процесу та його ID
            Console.WriteLine($"Process: {process.ProcessName}\tID: {process.Id}\tMemory: {Math.Round(process.WorkingSet64 / 1024.0, 2)} KB   {Math.Round(process.PrivateMemorySize64 / 1024.0, 2)} KB");
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
    Console.Clear(); // очищаємо консоль перед наступним виведенням
}
Console.Clear(); // очищаємо консоль перед наступним виведенням
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


