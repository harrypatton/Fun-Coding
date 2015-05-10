using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Traverser
    {
        public static void PrintNode(GraphNode node) {
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(node);
            node.IsVisiting = true;            

            while(q.Any()) {
                GraphNode testNode = q.Dequeue();
                Console.Write(testNode.Value + ", ");

                testNode.IsVisited = true;

                foreach(GraphNode childNode in testNode.AdjacentNodes.Where(childNode => !(childNode.IsVisited || childNode.IsVisiting ))) {
                    q.Enqueue(childNode);
                    childNode.IsVisiting = true;
                }
            }
        }
    }
}
