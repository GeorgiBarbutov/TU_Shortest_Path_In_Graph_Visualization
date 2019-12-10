using System.Collections.Generic;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Graph : IGraph
    {
        private const float CENTER_X = 490f;
        private const float CENTER_Y = 195f;
        private const int DEFAULT_NODE_NUMBER = 1;

        private List<INode> nodes;

        public Graph()
        {
            this.Nodes = new List<INode>();
            this.CurrentNodeNumber = DEFAULT_NODE_NUMBER;
        }

        public Graph(int nodeNumber)
        {
            this.Nodes = new List<INode>();
            this.CurrentNodeNumber = nodeNumber;
        }

        public int CurrentNodeNumber { get; private set; }

        public IReadOnlyList<INode> Nodes {
            get => this.nodes;
            private set => this.nodes = (List<INode>)value;
        }

        public INode AddExistingNode(int layer, int nodeNumber, float centerX, float centerY)
        {
            INode node = new Node(nodeNumber, layer, new Point(centerX, centerY));

            this.nodes.Add(node);

            return node;
        }

        public ILink AddLink(INode node1, INode node2, int weight)
        {
            ILink link = new Link(node1, node2, weight);

            ((Node)node1).AddLink(link);
            ((Node)node2).AddLink(link);

            return link;
        }

        public INode AddNode(int layer)
        {
            INode node = new Node(this.CurrentNodeNumber, layer, new Point(CENTER_X, CENTER_Y));

            this.nodes.Add(node);

            this.CurrentNodeNumber += 1;

            return node;
        }

        public INode AddNode(int layer, IPoint center)
        {
            INode node = new Node(this.CurrentNodeNumber, layer, center);

            this.nodes.Add(node);

            this.CurrentNodeNumber += 1;

            return node;
        }

        public void RemoveLink(ILink link)
        {
            foreach (INode node in this.Nodes)
            {
                foreach (ILink connectedLink in node.ConnectedLinks)
                {
                    if(connectedLink == link)
                    {
                        ((Node)link.ConnectedNodes.Item1).RemoveLink(link);
                        ((Node)link.ConnectedNodes.Item2).RemoveLink(link);

                        return;
                    }
                }
            }
        }

        public void RemoveNode(INode node)
        {
            this.nodes.Remove(node);

            foreach (ILink link in node.ConnectedLinks)
            {
                if(link.ConnectedNodes.Item1 == node)
                {
                    ((Node)link.ConnectedNodes.Item2).RemoveLink(link);
                }
                else
                {
                    ((Node)link.ConnectedNodes.Item1).RemoveLink(link);
                }
            } 
        }
    }
}
