using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph {

    public class GraphNode {
        public int Value { get; set; }

        public List<GraphNode> AdjacentNodes { get; private set; }

        public bool IsVisited { get; set; }

        public bool IsVisiting { get; set; }

        public GraphNode(int value) {
            this.Value = value;
            this.AdjacentNodes = new List<GraphNode>();
            this.IsVisited = false;
            this.IsVisiting = false;
        }

        public void AddAdjacentNode(GraphNode node) {
            this.AdjacentNodes.Add(node);
        }

        public void RemoveAdjacentNode(GraphNode node) {
            this.AdjacentNodes.Remove(node);
        }
    }
}
