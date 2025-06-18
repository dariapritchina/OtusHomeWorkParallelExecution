namespace HomeWorkParallel;

public class PLinqSumExecutor : IExecutor
{
    public long CalculateSum(int[] array)
    {
        var size = array.Length;
        return array
            .AsParallel()
            .AsUnordered()
            .Sum();
    }
}