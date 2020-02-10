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

        public List<string> DepthFirstSearch(List<string> output = null)
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
    }
}