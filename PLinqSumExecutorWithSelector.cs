namespace HomeWorkParallel;

public class PLinqSumExecutorWithSelector : IExecutor
{
    public long CalculateSum(int[] array)
    {
        var size = array.Length;
        return array
            .AsParallel()
            .AsUnordered()
            .Sum(x => x);
    }
}