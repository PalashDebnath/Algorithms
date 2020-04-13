using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public class MedianHandler
    {
        public double Median { get; private set; }
        private HeapBuilder maxHeap;
        private HeapBuilder minHeap;

        public MedianHandler()
        {
            this.maxHeap = new HeapBuilder((a, b) => a > b, new List<int>());
            this.minHeap = new HeapBuilder((a, b) => a < b, new List<int>());
        }

        public void Insert(int number)
        {
            if(maxHeap.heap.Count == 0 || maxHeap.Peek() > number)
            {
                maxHeap.Insert(number);
            }
            else
            {
                minHeap.Insert(number);
            }
            BalanceHeap();
            SetMedian();
        }

        private void BalanceHeap()
        {
            if(minHeap.heap.Count - maxHeap.heap.Count == 2)
            {
                maxHeap.Insert(minHeap.Remove());
            }
            else if(maxHeap.heap.Count - minHeap.heap.Count == 2)
            {
                minHeap.Insert(maxHeap.Remove());
            }
        }

        private void SetMedian()
        {
            if(minHeap.heap.Count == maxHeap.heap.Count)
            {
                Median = ((double)minHeap.Peek() + (double)maxHeap.Peek()) / 2;
            }
            else if(minHeap.heap.Count > maxHeap.heap.Count)
            {
                Median = minHeap.Peek();
            }
            else
            {
                Median = maxHeap.Peek();
            }
        }
    }
}