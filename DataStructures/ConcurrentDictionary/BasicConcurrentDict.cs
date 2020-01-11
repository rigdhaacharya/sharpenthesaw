using System;

namespace ConcurrentDictionary
{
    /// <summary>
    /// This is a basic concurrent dictionary. We don't handle expanding the array
    /// or hash collisions here and we only handle int values
    /// </summary>
    public class BasicConcurrentDict
    {
        /// <summary>
        /// This is the total size of our dictionary. We can expand arrays later for more real use cases
        /// </summary>
        private const int _size = 1024; 
        /// <summary>
        /// How many items in each segment or chunk for locking
        /// </summary>
        private const int _segmentSize = 8;
        /// <summary>
        /// The array for the dictionary
        /// </summary>
        private int[] _array = new Int32[_size];
        /// <summary>
        /// Array of locks for concurrency
        /// </summary>
        private object[] _locks = new Object[_size / _segmentSize];

        /// <summary>
        /// Default constructor, just initializes the objects
        /// </summary>
        public BasicConcurrentDict()
        {
            //initialize the value array with -1
            for (int i = 0; i < _size; i++)
            {
                _array[i] = -1;
            }
            //initialize the locks with empty objects
            var lockSize = _size / _segmentSize;
            for (int i = 0; i < lockSize; i++)
            {
                _locks[i]= new object();
            }
        }

        /// <summary>
        /// Adds or updates the value of an item in the dictionary
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value for the key</param>
        public void AddOrUpdate(string key, int value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception($"Key cannot be null, empty or whitespace");
            }

            var index = GetHashIndex(key);
            
            var lockIndex = index / _segmentSize;
            lock (_locks[lockIndex])
            {
                _array[index] = value;
            }

        }

        /// <summary>
        /// Adds or updates the value of an item in the dictionary
        /// </summary>
        /// <param name="key">Key</param>
        public int Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new Exception($"Key cannot be null, empty or whitespace");
            }

            var index = GetHashIndex(key);
            var lockIndex = index / _segmentSize;
            lock (_locks[lockIndex])
            {
               return _array[index];
            }

        }

        private int GetHashIndex(string key)
        {
            //not great but we're pretending there's no hash collision
            return Math.Abs(key.GetHashCode() % _size);
        }
    }
}
