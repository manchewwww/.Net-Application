namespace Orleans.Grains
{
    public class CounterGrain : Grain, ICounterGrain
    {
        private int _count;

        public Task<int> Increment()
        {
            _count++;
            return Task.FromResult(_count);
        }

        public Task<int> GetCount()
        {
            return Task.FromResult(_count);
        }
    }
}