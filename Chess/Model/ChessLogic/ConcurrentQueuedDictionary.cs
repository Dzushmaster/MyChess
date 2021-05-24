using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    class ConcurrentQueuedDictionary<TKey, TValue>
    {
        Task clearingTask = Task.Delay(0);
        ConcurrentDictionary<TKey, TValue> dictionary;
        ConcurrentQueue<TKey> keys;
        readonly int clearedCapacity;
        public ConcurrentQueuedDictionary(int capacity)
        {
            keys = new ConcurrentQueue<TKey>();
            clearedCapacity = (int)(capacity * 0.95);
            dictionary = new ConcurrentDictionary<TKey, TValue>();
        }
        public void TryAdd(TKey key, TValue value)
        {
            if (dictionary.TryAdd(key, value))
                keys.Enqueue(key);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            return dictionary.TryGetValue(key, out value);
        }
    }
}
