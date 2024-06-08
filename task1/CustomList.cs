using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class CustomList<T> :IEnumerable<T>
    {
        private int capacity;
        private int count;
        public int Capacity { get => capacity; }
        public int Count { get => count; }
        private T[] items;
        public T[] Items { get => items; }

        private int InitialCount = 4;

        public CustomList()
        {
            items = new T[0];
            capacity = items.Length;
        }

        public void Add(T item)
        {
            if (count == capacity)
            {

                Array.Resize(ref items, capacity == 0 ? InitialCount : items.Length * 2);
                capacity = items.Length;
            }

            items[count] = item;
            count++;
        }

        public void GetAll()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
        public void Remove(T item)
        {
            var index = Array.IndexOf(items, item);
            if (index != -1)
            {
                for (int i = 0; i < count; i++)
                {
                    items[i] = items[i + 1];
                }
                count--;

            }
        }

        public bool Contains(T item)
        {
            var index = Array.IndexOf<T>(items, item);
            if (index != -1)
                return true;
            return false;
        }

        public bool Any(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate == null)
                return true;
            foreach (var item in items)
            {
                if (predicate(item)) return true;
            }


            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
                items[i] = default;
            count = 0;
        }

        public T FirstOrDefault(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate == null)
                return items[0];
            foreach(var item in items)
            {
                if(predicate(item)) return item;
            }

            return default;
        }

        public T ElementAtOrDefault(int index)
        {
            if (count <= index)
                return default;
            else return items[index];
        }

        public T LastOrDefault(Predicate<T> predicate = null)
        {
            if (count > 0 && predicate == null)
                return items[count-1];
            for(int i = count - 1; i >= 0; i--) 
            {
                if (predicate(items[i])) return items[i];
            }

            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}