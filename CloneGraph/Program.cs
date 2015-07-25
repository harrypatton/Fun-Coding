using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneGraph {
    class Program {
        static void Main(string[] args) {
        }
    }
    public class UndirectedGraphNode {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    public class Solution {

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
            Dictionary<int, UndirectedGraphNode> newNodes = new Dictionary<int, UndirectedGraphNode>();
            Dictionary<int, bool> isVisited = new Dictionary<int, bool>();
            return CloneGraph(node, newNodes, isVisited);
        }

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> newNodes, Dictionary<int, bool> isVisited) {

            if (node == null) {
                return node;
            }
            
            var newNode = GetOrCreateNewNode(node.label, newNodes);

            if (!isVisited.ContainsKey(node.label)) {
                foreach (var neighbor in node.neighbors) {
                    newNode.neighbors.Add(CloneGraph(neighbor));
                }

                isVisited.Add(node.label, true);
            }
            
            return newNode;
        }

        public UndirectedGraphNode CloneGraphStack(UndirectedGraphNode node) {

            if (node == null) {
                return node;
            }

            Dictionary<int, bool> neighborAdded = new Dictionary<int, bool>();
            Dictionary<int, UndirectedGraphNode> newNodes = new Dictionary<int, UndirectedGraphNode>();

            Stack<UndirectedGraphNode> stack = new Stack<UndirectedGraphNode>();
            stack.Push(node);

            while (stack.Any()) {
                UndirectedGraphNode originalNode = stack.Pop();

                if (!neighborAdded.ContainsKey(originalNode.label)) {
                    neighborAdded[originalNode.label] = true;
                    UndirectedGraphNode newNode = GetOrCreateNewNode(originalNode.label, newNodes);

                    foreach(var neighbor in originalNode.neighbors) {
                        UndirectedGraphNode newNeighborNode = GetOrCreateNewNode(neighbor.label, newNodes);
                        newNode.neighbors.Add(newNeighborNode);

                        if (!neighborAdded.ContainsKey(neighbor.label)) {
                            stack.Push(neighbor);
                        }
                    }
                }
            }

            return newNodes[node.label];
        }

        public UndirectedGraphNode GetOrCreateNewNode(int label, Dictionary<int, UndirectedGraphNode> newNodes) {

            UndirectedGraphNode node = null;

            if (newNodes.ContainsKey(label)) {
                node = newNodes[label];
            }
            else {
                node = new UndirectedGraphNode(label);
                newNodes.Add(label, node);
            }

            return node;
        }
    }
}
