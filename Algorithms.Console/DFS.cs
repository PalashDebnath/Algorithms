using System.Collections.Generic;

namespace Algorithms.Application
{
    public class DFSNode
    {
        public string name;
        public List<DFSNode> children;

        public DFSNode(string name)
        {
            this.name = name;
            this.children = new List<DFSNode>();
        }

        public DFSNode AddDFSNode(string name)
        {
            DFSNode child = new DFSNode(name);
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
                foreach(DFSNode child in children)
                {
                    child.DepthFirstSearch(output);
                }
            }
            return output;
        }
    }
}