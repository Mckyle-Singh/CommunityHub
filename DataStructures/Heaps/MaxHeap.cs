using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.DataStructures.Heaps
{
    public class MaxHeap<T>
    {
        private readonly List<T> heap = new List<T>();
        private readonly Comparison<T> comparator;

        public MaxHeap(Comparison<T> comparison)
        {
            comparator = comparison ?? throw new ArgumentNullException(nameof(comparison));
        }

        public int Count => heap.Count;

        public void Insert(T item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public T ExtractMax()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

            T max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return max;
        }

        public List<T> PeekTopN(int n)
        {
            var copy = new List<T>(heap);
            copy.Sort((a, b) => comparator(b, a)); // descending
            return copy.GetRange(0, Math.Min(n, copy.Count));
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (comparator(heap[index], heap[parent]) <= 0) break;

                Swap(index, parent);
                index = parent;
            }
        }

        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;

            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int largest = index;

                if (left <= lastIndex && comparator(heap[left], heap[largest]) > 0)
                    largest = left;

                if (right <= lastIndex && comparator(heap[right], heap[largest]) > 0)
                    largest = right;

                if (largest == index) break;

                Swap(index, largest);
                index = largest;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
