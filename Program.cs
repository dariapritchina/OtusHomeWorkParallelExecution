using System.Diagnostics;
using HomeWorkParallel;

int[] sizes = { 100_000, 1_000_000, 10_000_000, 100_000_000 };
var executors = new IExecutor[]
{
    new SimpleSumExecutor(),
    new ThreadSumExecutor(),
    new PLinqSumExecutor(),
    // new PLinqSumExecutorWithSelector()
};

var printer = new ConsolePrinter();
printer.EnvironmentInfo();

var sw = Stopwatch.StartNew();
foreach (var size in sizes)
{
    printer.Separator();
    printer.PrintSize(size);
    foreach (var executor in executors)
    {
        var array = CreateData(size);

        sw.Restart();
        var sum = executor.CalculateSum(array);
        sw.Stop();

        printer.InfoAboutExecution(executor, sw);
    }
}

int[] CreateData(int size)
{
    var DEFAULT_VALUE = 1;
    var data = new int[size];

    for (var i = 0; i < size; i++)
    {
        data[i] = DEFAULT_VALUE;
    }

    return data;
}