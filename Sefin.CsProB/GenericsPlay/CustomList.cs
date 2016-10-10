using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPlay
{
    public class CustomList<T> where T : class
    {
        T[] _storage = new T[1000];
        int _lastIndex;

        public void Add(T item) {
            _storage[_lastIndex] = item;
            _lastIndex++;
        }

        public T Get(int index)
        {
            return _storage[index];
        }

        public void Remove(int index) {
            //_storage[index] = default(T);
            _storage[index] = null;
        }
    }
}
