using System;

namespace MedianFinder
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;

    public class MedianFinderSortedSet
    {
        private SortedDictionary<int, int> maxHeap;
        private SortedDictionary<int, int> minHeap;

        private int maxHeapCount;
        private int minHeapCount;

        public MedianFinderSortedSet()
        {
            this.maxHeap = new SortedDictionary<int, int>();
            this.minHeap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            this.maxHeapCount = 0;
            this.minHeapCount = 0;
        }

        public void AddNum(int num)
        {
            //try to add to maxHeap first
            Add(num, maxHeap, ref maxHeapCount);
            //offer the top of maxHeap to minHeap
            var maxHeapMax = maxHeap.First();
            Remove(maxHeapMax.Key, maxHeap, ref maxHeapCount);
            //add to minHeap
            Add(maxHeapMax.Key, minHeap, ref minHeapCount);
            //if minHeap is larger, offer the min val to max heap
            if (minHeapCount > maxHeapCount)
            {
                var minVal = minHeap.First();
                Remove(minVal.Key, minHeap, ref minHeapCount);
                Add(minVal.Key, maxHeap, ref maxHeapCount);
            }
            //done
        }

        public double FindMedian()
        {
            if (minHeapCount == maxHeapCount)
            {
                return ((double)maxHeap.First().Key + minHeap.First().Key) / 2;
            }
            else
            {
                return maxHeap.First().Key;
            }
        }

        private void Add(int num, SortedDictionary<int, int> d, ref int count)
        {
            if (d.ContainsKey(num))
            {
                d[num]++;
            }
            else
            {
                d.Add(num, 1);
            }

            count++;
        }

        private void Remove(int num, SortedDictionary<int, int> d, ref int count)
        {
            if (!d.ContainsKey(num))
                return;

            d[num]--;
            if (d[num] == 0)
                d.Remove(num);

            count--;
        }
    }
}
