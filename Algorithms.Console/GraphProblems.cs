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

    public class Member
    {
        public char name;
        public Member ancestor;

        public Member(char name)
        {
            this.name = name;
            this.ancestor = null;
        }

        public void AddAsAncestor(Member[] descendants)
        {
            foreach(Member descendant in descendants)
            {
                descendant.ancestor = this;
            }
        }

        //Time Complexity: O(d) where d is the largest depth of the descendant.
        //Space complexity: O(1)
        public static Member GetYoungestCommonAncestor(Member firstDescendant, Member secondDescendant)
        {
            Member ancestor = firstDescendant.ancestor;
            int firstDepth = 0, secondDepth = 0;
            while(ancestor != null)
            {
                firstDepth = firstDepth + 1;
                ancestor = ancestor.ancestor;
            }

            ancestor = secondDescendant.ancestor;
            while(ancestor != null)
            {
                secondDepth = secondDepth + 1;
                ancestor = ancestor.ancestor;
            }

            if(firstDepth > secondDepth)
            {
                while(firstDepth != secondDepth)
                {
                    firstDescendant = firstDescendant.ancestor;
                    firstDepth = firstDepth - 1;
                }
                while(firstDescendant != secondDescendant)
                {
                    firstDescendant = firstDescendant.ancestor;
                    secondDescendant = secondDescendant.ancestor;
                }
            }
            else if(firstDepth < secondDepth)
            {
                while(firstDepth != secondDepth)
                {
                    secondDescendant = secondDescendant.ancestor;
                    secondDepth = secondDepth - 1;
                }
                while(firstDescendant != secondDescendant)
                {
                    firstDescendant = firstDescendant.ancestor;
                    secondDescendant = secondDescendant.ancestor;
                }
            }
            else
            {
                while(firstDescendant != secondDescendant)
                {
                    firstDescendant = firstDescendant.ancestor;
                    secondDescendant = secondDescendant.ancestor;
                }
            }
            return firstDescendant;
        }
    }

    public class Graph
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool HasCycleAtFirstPosition(int[] array)
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
        public static bool HasCycleAtNthPosition(int[] array, int startIndex)
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
        public static int TotalNumberOfCycle(int[] array)
        {
            int cycles = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(HasCycleAtNthPosition(array, i))
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
    
        //Time Complexity: O(wh) where w is the width of the matrix and h is the height of the matrix
        //Space Complexity: O(wh) we will have the maximum number of recursive frames in call stack is multiplcation of width * height
        public static List<int> RiverSizes(int[,] matrix)
        {
            List<int> sizes = new List<int>();
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j] == 1)
                    {
                        List<int> streams = new List<int>();
                        streams.Add(i + j);
                        TraverseNode(i, j, matrix, streams);
                        if(streams.Count > 0)
                        {
                            sizes.Add(streams.Count);
                        }
                    }
                }
            }
            return sizes;
        }

        private static void TraverseNode(int i, int j, int[,] matrix, List<int> streams)
        {
            matrix[i, j] = 0;
            if(i > 0 && matrix[i - 1, j] == 1)
            {
                streams.Add(i-1+j);
                TraverseNode(i-1, j, matrix, streams);                
            }
            if(i < matrix.GetLength(0) - 1 && matrix[i + 1, j] == 1)
            {
                streams.Add(i+1+j);
                TraverseNode(i+1, j, matrix, streams);
            }
            if(j > 0 && matrix[i, j - 1] == 1)
            {
                streams.Add(i+j-1);
                TraverseNode(i, j-1, matrix, streams);
            }
            if(j < matrix.GetLength(1) - 1 && matrix[i, j + 1] == 1)
            {
                streams.Add(i+j+1);
                TraverseNode(i, j+1, matrix, streams);
            }
        }
    }
}