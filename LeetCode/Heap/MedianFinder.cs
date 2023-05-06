namespace LeetCode.Heap
{
    // Sorting
    // O(nlogn) time, O(n) space
    public class MedianFinderV1
    {
        private readonly List<int> _store;
        public MedianFinderV1() 
            => _store = new List<int>();

        public void AddNum(int num) 
            => _store.Add(num);

        public double FindMedian()
        {
            _store.Sort();
            int n = _store.Count;
            return (n % 2 == 1) ?
                _store[n / 2] : 
                ((double)_store[n / 2 - 1] + _store[n / 2]) * 0.5;
        }
    }

    // Two Heaps
    // O(5*logn) + O(1) ~= O(logn) time, O(n) space
    public class MedianFinderV2
    {
        private readonly PriorityQueue<int, int> _maxHeap;
        private readonly PriorityQueue<int, int> _minHeap;
        public MedianFinderV2()
        {
            // A max-heap to store the smaller half of the input numbers
            // A min - heap to store the larger half of the input numbers
            _maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            _minHeap = new PriorityQueue<int, int>();
        }

        public void AddNum(int num)
        {
            // Add to max heap
            _maxHeap.Enqueue(num, num);

            var loTop = _maxHeap.Peek();
            // balancing step
            _minHeap.Enqueue(loTop, loTop);
            _maxHeap.Dequeue();

            if (_maxHeap.Count < _minHeap.Count)
            {
                // maintain size property
                var hiTop = _minHeap.Peek();
                _maxHeap.Enqueue(hiTop, hiTop);
                _minHeap.Dequeue();
            }
        }

        public double FindMedian()
            => (_maxHeap.Count > _minHeap.Count) ?
                    _maxHeap.Peek() :
                    ((double)_maxHeap.Peek() + _minHeap.Peek()) * 0.5;
    }
}