using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public class HeapBuilder
    {
        public List<int> heap { get; private set; }
        private Func<int, int, bool> compare; 

        public HeapBuilder(Func<int, int, bool> compare, List<int> array)
        {
            this.heap = array;
            this.compare = compare;
            Build();
        }

        //Time Complexity: O(log(n))
        //Spcae Complexity: O(1)
        public void SiftDown(int currentIndex, int endIndex)
        {
            int firstChildIndex = 2 * currentIndex + 1;
			while(firstChildIndex <= endIndex)
            {
                int secondChildIndex = (2 * currentIndex + 2) <= endIndex ? 2 * currentIndex + 2 : -1;
                int targetChildIndex;

                if(secondChildIndex != -1 && compare(heap[secondChildIndex], heap[firstChildIndex]))
                {
                    targetChildIndex = secondChildIndex;
                }
                else
                {
                    targetChildIndex = firstChildIndex;
                }
                
                if(compare(heap[targetChildIndex], heap[currentIndex]))
                {
                    Swap(currentIndex, targetChildIndex);
                    currentIndex = targetChildIndex;
                    firstChildIndex = 2 * currentIndex + 1;
                }
                else
                {
                    break;
                }
            }
		}

        //Time Complexity: O(log(n))
        //Spcae Complexity: O(1)
		public void SiftUp(int currentIndex)
        {
			int parentIndex = (currentIndex - 1) / 2;
            while(currentIndex > 0 && compare(heap[currentIndex], heap[parentIndex]))
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
		}

        //Time Complexity: O(1)
        //Spcae Complexity: O(1)
		public int Peek() 
        {
			return heap[0];
		}

        //Time Complexity: O(log(n))
        //Spcae Complexity: O(1)
		public int Remove() 
        {
            int targetValue = heap[0];
			Swap(0, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            SiftDown(0, heap.Count - 1);
			return targetValue;
		}

        //Time Complexity: O(log(n))
        //Spcae Complexity: O(1)
		public void Insert(int value) 
        {
			heap.Add(value);
            SiftUp(heap.Count - 1);
		}

        //Time Complexity: O(n)
        //Spcae Complexity: O(1)
        private void Build()
        {
            int firstParentIndex = (heap.Count - 2) / 2;
            int endIndex = heap.Count - 1;
            for (int currentIndex = firstParentIndex; currentIndex >= 0; currentIndex--)
            {
                SiftDown(currentIndex, endIndex);
            } 
        }

        //Time Complexity: O(1)
        //Spcae Complexity: O(1)
        private void Swap(int sourceIndex, int targetIndex)
        {
            int temp = heap[sourceIndex];
            heap[sourceIndex] = heap[targetIndex];
            heap[targetIndex] = temp;
        }
    }
}