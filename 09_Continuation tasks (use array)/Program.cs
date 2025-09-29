
int[] arr = new int[10];

Task taskGen = Task.Run(()=>
{
    Random rand = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rand.Next(1, 100);
    }
    Console.WriteLine("Array generated: " + string.Join(", ", arr));
});

Task < int[]> taskSort = taskGen.ContinueWith(prevTask =>
{
    int[] sorted = (int[])arr.Clone();
    Array.Sort(sorted);
    Console.WriteLine("Array sorted");
    //Console.WriteLine("Array sorted: " + string.Join(", ", sorted));
    return sorted;
});

//Task taskPrint = taskSort.ContinueWith(prevTask => // lambda
//{
//    int[] sorted = prevTask.Result;
//    Console.WriteLine("Sorted array:");
//    for (int i = 0; i < sorted.Length; i++)
//    {
//        Console.Write(sorted[i] + " ");
//    }
//    Console.WriteLine();
//});
Task taskPrint = taskSort.ContinueWith(prevTask => 
{
   // int[] sorted = prevTask.Result;
    //PrintArray(sorted);
    PrintArray(prevTask.Result); // друк чисел виконуэ функція PrintArray
});

//taskPrint.Wait();
await taskPrint;

void PrintArray(int[] array)
{
    Console.WriteLine("Array: ");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
    Console.WriteLine();
}
