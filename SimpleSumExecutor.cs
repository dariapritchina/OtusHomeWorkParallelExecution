public class SimpleSumExecutor : IExecutor
{
    public long CalculateSum(int[] array)
    {
        long sum = 0;
        
        foreach (var item in array)
        {
            sum += item;
        }

        return sum;
    }
}