using System.Collections.Generic;
using System.Linq;
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
            this.Source = null;
            this.Destination = null;
        }

        public Graph(int nodeNumber)
        {
            this.Nodes = new List<INode>();
            this.CurrentNodeNumber = nodeNumber;
            this.Source = null;
            this.Destination = null;
        }

        public int CurrentNodeNumber { get; private set; }

        public IReadOnlyList<INode> Nodes {
            get => this.nodes;
            private set => this.nodes = (List<INode>)value;
        }

        public INode Source { get; set; }

        public INode Destination { get; set; }

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

        public void Dijkstra()
        {
            foreach (INode node in this.Nodes)
            {
                node.ResetDjikstraParameters();
            }

            this.Source.DistanceFromSource = 0;

            INode currentNode = this.Source;

            while (true)
            {
                foreach (ILink link in currentNode.ConnectedLinks)
                {
                    INode otherNode;
                    if (link.ConnectedNodes.Item1 == currentNode)
                    {
                        otherNode = link.ConnectedNodes.Item2;
                    }
                    else
                    {
                        otherNode = link.ConnectedNodes.Item1;
                    }

                    if (!otherNode.IsVisited)
                    {
                        int tentativeDistance = currentNode.DistanceFromSource + link.Weight;

                        if (tentativeDistance < otherNode.DistanceFromSource)
                        {
                            otherNode.DistanceFromSource = tentativeDistance;
                            otherNode.PreviousNode = currentNode;
                        }
                    }
                }

                currentNode.IsVisited = true;

                if (this.Destination.IsVisited)
                {
                    break;
                }
                else
                {
                    currentNode = this.Nodes.Where(n => !n.IsVisited).OrderBy(n => n.DistanceFromSource).ToArray()[0];
                }
            }
        }
    }
}
