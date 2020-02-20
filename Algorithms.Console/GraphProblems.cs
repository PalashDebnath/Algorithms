using System.Collections.Generic;

namespace Algorithms.Application
{
    public class Node
    {
        public string name;
        public List<Node> children;

        public Node(string name)
        {
            this.name = name;
            this.children = new List<Node>();
        }

        public Node AddNode(string name)
        {
            Node child = new Node(name);
            children.Add(child);
            return this;
        }

        //Time Complexity: O(V + E) where V are the vertices or the nodes and E are the edge or connection
        //Space Complexity: O(V) where V are the vertices. if you have one big chain, you need to go through all the vertices.
        //So there will be V number of recursive calling frames in call stack
        public List<string> DepthFirstSearch(List<string> output)
        {
            if(this.children != null)
            {
                output.Add(this.name);
                foreach(Node child in children)
                {
                    child.DepthFirstSearch(output);
                }
            }
            return output;
        }

        //Time Complexity: O(V + E) where V are the vertices or the nodes and E are the edge or connection
        //Space Complexity: O(V) where V are the vertices. if you have one big chain, you need to go through all the vertices.
        //So there will be V number of recursive calling frames in call stack
        public List<string> BreadthFirstSearch(List<string> output)
        {
            List<Node> queue = new List<Node>();
            int current = 0;
            queue.Add(this);
            while(current < queue.Count)
            {
                foreach(Node child in queue[current].children)
                {
                    queue.Add(child);
                }
                output.Add(queue[current].name);                
                current = current + 1;
            }
            return output;
        }
    }

    public class CycleCheck
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool HasAtFirstPosition(int[] array)
        {
            int currentIndex = 0, jumps = 0;
            while(jumps < array.Length)
            {
                if(jumps > 0 && currentIndex == 0)
                {
                    return false;
                }
                jumps = jumps + 1;
                currentIndex = GetTargetIndex(currentIndex, array);
            }
            return currentIndex == 0;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool HasAtNthPosition(int[] array, int startIndex)
        {
            int currentIndex = startIndex, jumps = 0;
            while(jumps < array.Length)
            {
                if(jumps > 0 && currentIndex == startIndex)
                {
                    return false;
                }
                jumps = jumps + 1;
                currentIndex = GetTargetIndex(currentIndex, array);
            }
            return currentIndex == startIndex;
        }

        //Time Complexity: O(n^2)
        //Space Complexity: O(1)
        public static int TotalNumber(int[] array)
        {
            int cycles = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(HasAtNthPosition(array, i))
                {
                    cycles = cycles + 1;
                }
            }
            return cycles;
        }

        private static int GetTargetIndex(int currentIndex, int[] array)
        {
            int jump = array[currentIndex];
            //In c# Mod of negative number works as below
            //-5%5=0;-4%5=-4;-3%5=-3
            int nextIndex = (currentIndex + jump) % array.Length;
            return nextIndex >= 0 ? nextIndex : nextIndex + array.Length;
        }
    }
}