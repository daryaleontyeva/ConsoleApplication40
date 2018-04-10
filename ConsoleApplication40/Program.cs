using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hashable
{
    public class HashTable
    {

        private KeyValuePair[] _array;
        private int currentOffset;
        public HashTable(int size)
        {
            _array = new KeyValuePair[size];
        }
        public void PutPair(object key, object value)
        {

            var hashCode = key.GetHashCode();
            var bucketNumber = GetBucketNumber(key);

            var bucket = _array[bucketNumber];
            while (bucket != null)
            {
                if (Equals(bucket.Key, key))
                {
                    bucket.Value = value;
                    return;
                }
                bucket = bucket.Next;
            }

            var writeBucket = _array[bucketNumber];
            if (writeBucket == null)
            {
                _array[bucketNumber] = new KeyValuePair { Value = value, Key = key };
            }
            else
            {
                while (writeBucket.Next != null)
                {
                    writeBucket = writeBucket.Next;
                }
                writeBucket.Next = new KeyValuePair { Value = value, Key = key };
            }

        }
        private int GetBucketNumber(object key)
        {
            var hashCode = key.GetHashCode();
            var bucketNumber = Math.Abs(hashCode) % _array.Length;
            return bucketNumber;
        }
        public object GetValueByKey(object key)
        {

            var bucketNumber = GetBucketNumber(key);
            var bucket = _array[bucketNumber];
            while (bucket != null)
            {
                if (Equals(bucket.Key, key))
                {
                    return bucket.Value;
                }
                bucket = bucket.Next;
            }
            return null;

        }
        class KeyValuePair
        {
            public Object Key { get; set; }
            public Object Value { get; set; }
            public KeyValuePair Next { get; set; }
        }
    }
}
