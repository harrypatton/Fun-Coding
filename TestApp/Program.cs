using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp {
    class Program {
        static void Main(string[] args) {
            GraphNode node1 = new GraphNode(1);
            GraphNode node2 = new GraphNode(2);
            GraphNode node3 = new GraphNode(3);

            node1.AdjacentNodes.AddRange(new GraphNode[] { node2, node3 });
            node2.AdjacentNodes.AddRange(new GraphNode[] { node1, node3 });
            node3.AdjacentNodes.AddRange(new GraphNode[] { node1, node2 });

            Traverser.PrintNode(node1);
        }
    }
}
