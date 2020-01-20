using System;

namespace MedianFinder
{
    using System.Collections.Generic;
    using System.Net.Http.Headers;

    public class MedianFinderSimple
    {
        private bool _sorted;

        private List<int> _values;
        /** initialize your data structure here. */
        public MedianFinderSimple()
        {
            _values = new List<int>();
        }

        public void AddNum(int num)
        {
            _sorted = false;
            _values.Add(num);
        }

        public double FindMedian()
        {
            if (!_sorted)
            {
                _values.Sort();
                _sorted = true;
            }
           
            if (_values.Count % 2 == 0)
            {
                return ((double)_values[(_values.Count / 2 + 1)-1] + _values[(_values.Count-1) / 2]) / 2.0;
            }
            else
            {
                return (double) _values[_values.Count / 2];
            }
        }
    }
}
