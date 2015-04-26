using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetListOfT
{
    class MyList<T> : IEnumerable<T>
    {
        private int index = 0;
        private T[] list;
        private readonly int capacity;

        public MyList(int capacity)
        {
            list = new T[capacity];
            this.capacity = capacity;
        } 

        public int Count()
        {
            return index;
        }

        public void Add(T item)
        {
            list[index] = item;
            index++;
        }

        public T this[int index]
        {   
            get 
            {
                if(index < 0 || index >= Count())
                    throw new ArgumentOutOfRangeException();

                return list[index];
            }

            set
            {
                if(index < 0 || index >= Count())
                    throw new ArgumentOutOfRangeException();

                list[index] = value;
            }
        }

        public void Clear()
        {
            list = new T[capacity];
            index = 0;
        }

        public bool Contains(T item)
        {
            foreach (var x in list)
            {
                if (x.Equals(item))
                    return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < Count(); i++)
            {
                list[i] = list[i + 1];
            }

            list[Count() - 1] = default(T);
            this.index--;
        }

        public MyList<T> FindAll(Func<T, bool> match)
        {
            MyList<T> resultList = new MyList<T>(capacity);

            foreach (var x in list)
            {
                if(match(x))
                    resultList.Add(x);
            }

            return resultList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (list.Where(item => !item.Equals(default(T))) as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
