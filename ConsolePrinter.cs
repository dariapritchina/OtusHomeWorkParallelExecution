using System.Diagnostics;

namespace HomeWorkParallel;

public class ConsolePrinter
{
    public ConsolePrinter()
    {
        
    }

    public void Separator()
    {
        Console.WriteLine("==================");
    }

    public void EnvironmentInfo()
    {
        Separator();
        
        Console.WriteLine("Environment info:");
        Console.WriteLine($"Processors count: {Environment.ProcessorCount}");
        Console.WriteLine($"OSVersion: {Environment.OSVersion.VersionString}");

        Separator();
    }

    public void InfoAboutExecution(IExecutor executor, Stopwatch sw)
    {
        var timeInMs = sw.ElapsedMilliseconds;
        Console.WriteLine($"{executor.GetType().Name}:".PadLeft(18) 
                          // + " ExecutionTime: " 
                          + $"{timeInMs} ms".PadLeft(10));
    }

    public void PrintSize(int size)
    {
        Console.WriteLine($"Size:{size}");
    }

    public void Print(string? text)
    {
     Console.WriteLine(text);   
    }
}