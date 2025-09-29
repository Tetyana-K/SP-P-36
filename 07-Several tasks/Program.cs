double []arr = new double[] {1,2,3.5,4,5,6,7,8,9};

Task<double>[] tasks =  new Task<double>[2];
tasks[0] = Task.Run(() => Sum(arr));
tasks[1] = Task.Run(() => Product(arr));


Console.WriteLine(tasks[1].Status);
double[] results = await Task.WhenAll(tasks);
Console.WriteLine(tasks[0].Status);
Console.WriteLine(tasks[1].Status);

Console.WriteLine($"Result of task 0 (sum) : {results[0]}");
Console.WriteLine($"Result of task 1 (product) : {results[1]}");
double Product(double[] array)
{
    double product = 1;
    foreach (var item in array)
    {
        product *= item;
        Thread.Sleep(100); // Затримка для наочності
    }
    return product;
}   
double Sum(double[] array)
{
    double sum = 0;
    foreach (var item in array)
    {
        sum += item;
        Thread.Sleep(100); // Затримка для наочності
    }
    return sum;
}