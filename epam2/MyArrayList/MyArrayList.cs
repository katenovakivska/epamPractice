using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class MyArrayList<T> : IEnumerable<T>
    {
        private T[] array = new T[0];
        private int Offset;
        public int LowerBound { get; private set; }
        public int Capacity { get; private set; }

        public T this[int i]
        {
            get
            {
                if (i < LowerBound || i > Capacity + LowerBound - 1)
                    throw new IndexOutOfRangeException("Index is out of range");
                return array[i - Offset];
            }
            set
            {
                if (i < LowerBound || i > Capacity + LowerBound - 1)
                    throw new IndexOutOfRangeException("Index is out of range");
                array[i - Offset] = value;
            }
        }

        public MyArrayList() { }

        public MyArrayList(int LowerBound, int Capacity)
        {
            if (Capacity < 1)
                throw new ArgumentException();
            this.LowerBound = LowerBound;
            this.Capacity = Capacity;
            Offset = LowerBound;
            array = new T[this.Capacity];
        }

        public MyArrayList(T[] array)
        {
            if (array.Length < 1)
                throw new ArgumentException();
            this.Capacity = array.Length;
            this.array = new T[array.Length];
            array.CopyTo(this.array, 0);
        }

        public MyArrayList(T[] array, int LowerBound)
        {
            if (array.Length < 1)
                throw new ArgumentException("Length is must have positive value");
            this.array = new T[array.Length];
            this.LowerBound = this.LowerBound;
            this.Capacity = array.Length;
            Offset = LowerBound;
            array.CopyTo(this.array, 0);
        }

        public MyArrayList(MyArrayList<T> array)
        {
            if (array.Capacity < 1) throw new ArgumentException("Input array is empty");
            this.Capacity = array.Capacity;
            this.LowerBound = array.LowerBound;
            this.array = new T[this.Capacity];
            array.CopyTo(this);
        }

        public void CopyTo(T[] array)
        {
            if (array.Length < this.Capacity)
                throw new ArgumentException("Capacity of target array must be greater or equal to this array");

            for (int i = 0; i < this.Capacity; i++)
            {
                array[i] = this.array[i];
            }
        }

        public void CopyTo(MyArrayList<T> array)
        {
            if (array.Capacity < this.Capacity)
                throw new ArgumentException("Capacity of target array must be greater or equal to this array");

            for (int i = 0, k = array.LowerBound; i < this.Capacity; i++, k++)
            {
                array[k] = this.array[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

       
    }
}
