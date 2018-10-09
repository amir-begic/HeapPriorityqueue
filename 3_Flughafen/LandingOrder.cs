using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinMaxHeap;

namespace _3_Flughafen {
    public class LandingOrder {

        ArrayList priorityQueue = new ArrayList();

        public void AddAirplane(Airplane airplane) {
            priorityQueue.Add(airplane);
            Enqueue(priorityQueue.Count - 1);
        }

        public Airplane GetNextAirplane() {
            if (priorityQueue.Count <= 0)
            {
                return null;
            }
            var firstInQueue = priorityQueue[0];
            Swap(0, priorityQueue.Count - 1);
            priorityQueue.RemoveAt(priorityQueue.Count - 1);
            Dequeue(0);
            return (Airplane)firstInQueue;
        }

        public void Enqueue(int idx)
        {
            if (idx == 0)
            {
                return;
            }

            var pIndex = GetParentIndex(idx);
            if (Comparer.Default.Compare(priorityQueue[idx], priorityQueue[pIndex]) >= 0)
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

            if (priorityQueue.Count > leftChildIndex && Comparer.Default.Compare(priorityQueue[leftChildIndex], priorityQueue[smallest]) < 0)
            {
                smallest = leftChildIndex;
            }

            if (priorityQueue.Count > rightChildIndex && Comparer.Default.Compare(priorityQueue[rightChildIndex], priorityQueue[smallest]) < 0)
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

        public void Swap(int idx1, int idx2)
        {
            var temp = priorityQueue[idx1];
            priorityQueue[idx1] = priorityQueue[idx2];
            priorityQueue[idx2] = temp;
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
    }
}
