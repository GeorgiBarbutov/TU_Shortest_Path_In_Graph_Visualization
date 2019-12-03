using System;
using System.Collections.Generic;
using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Graph : IGraph
    {
        private const float CENTER_X = 490f;
        private const float CENTER_Y = 195f;
        private const int DEFAULT_NODE_NUMBER = 1;

        public Graph()
        {
            this.Nodes = new List<INode>();
            this.CurrentNodeNumber = DEFAULT_NODE_NUMBER;
        }

        public int CurrentNodeNumber { get; private set; }

        public List<INode> Nodes { get; private set; }

        public ILink AddLink(INode node1, INode node2, float weight)
        {
            ILink link = new Link(node1, node2, weight);

            ((Node)node1).AddLink(link);
            ((Node)node2).AddLink(link);

            return link;
        }

        public INode AddNode(int layer)
        {
            INode node = new Node(this.CurrentNodeNumber, layer, new PointF(CENTER_X, CENTER_Y));

            this.Nodes.Add(node);

            this.CurrentNodeNumber += 1;

            return node;
        }
    }
}
