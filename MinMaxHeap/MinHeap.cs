using System;
using System.Collections;
using System.Text;

namespace MinMaxHeap {
    /// <summary>
    /// Hinweis: Es wurde bewusst auf eine Abstrakte Klasse "Heap" verzichtet, um die Komplexität nicht unnötig zu erhöhen.
    /// </summary>
    public class MinHeap {
        private readonly ArrayList data;

        public MinHeap(ICollection data) : this() {
            foreach (var item in data) {
                this.Add(item);
            }
        }

        public MinHeap() {
            this.data = new ArrayList();
        }

        private static int GetParentIndex(int idx)
        {
            return (idx - 1) / 2;
        }

        private static int GetLeftIndex(int idx)
        {
            return 2 * idx + 1;
        }

        private static int GetRightIndex(int idx)
        {
            return 2 * idx + 2;
        }

        public void Add(object item)
        {
            data.Add(item);
            Enqueue(Size-1);
        }

        public bool Empty => this.data.Count <= 0;

        public int Size => this.data.Count;

        public object Peek()
        {
            if (Empty)
            {
                return "No Items in tree";
            }
            return data[0];
        }

        public object Pop()
        {
            if (Empty)
            {
                return "No Items in tree";
            }
            var firstInQueue = data[0];
            Swap(0, Size - 1);
            data.RemoveAt(Size - 1);
            Dequeue(0);
            return firstInQueue;
        }

        public void Swap(int idx1, int idx2)
        {
            var temp = data[idx1];
            data[idx1] = data[idx2];
            data[idx2] = temp;
        }

        public void Enqueue(int idx)
        {
            if (idx == 0)
            {
                return;
            }

            var pIndex = GetParentIndex(idx);
            if (Comparer.Default.Compare(data[idx], data[pIndex]) >= 0)
            {
                return;
            }

            Swap(idx, pIndex);
            Enqueue(pIndex);
        }

        public void Dequeue(int idx)
        {
            var leftChildIndex = GetLeftIndex(idx);
            var rightChildIndex = GetRightIndex(idx);
            var smallest = idx;

            if (Size > leftChildIndex && Comparer.Default.Compare(data[leftChildIndex], data[smallest]) < 0)
            {
                smallest = leftChildIndex;
            }

            if (Size > rightChildIndex && Comparer.Default.Compare(data[rightChildIndex], data[smallest]) < 0)
            {
                smallest = rightChildIndex;
            }

            if (smallest == idx)
            {
                return;
            }

            Swap(smallest, idx);
            Dequeue(smallest);
        }

        public void PrintHeap() {
            int iMax = this.data.Count - 1, i;
            if (iMax < -1)
                Console.WriteLine("[]");

            var b = new StringBuilder();
            b.Append('[');
            for (i = 0; i < iMax; i++) {
                b.Append(data[i]);
                b.Append(", ");
            }
            Console.WriteLine(b.Append(this.data[i]).Append(']'));
        }
    }
}
