namespace HomeWorkParallel;

public class ThreadSumExecutor : IExecutor
{
    public long CalculateSum(int[] array)
    {
        var size = array.Length;
        int cores = Environment.ProcessorCount;
        long chunkSize = (size) / cores;
        var threads = new List<Thread>(cores);
        long total = 0;
        object lockObj = new();

        for (var iCore = 0; iCore < cores; iCore++)
        {
            var start = (int)(iCore * chunkSize);
            var end = (iCore == cores - 1) ? size : (int)(start + chunkSize);

            Thread t = new(() =>
            {
                long localSum = 0;
                for (var j = start; j < end; j++)
                {
                    localSum += array[j];
                }

                lock (lockObj) { total += localSum; }
            });

            threads.Add(t);
            t.Start();
        }

        foreach (Thread t in threads)
        {
            t.Join();
        }

        return total;
    }
}