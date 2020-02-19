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
}