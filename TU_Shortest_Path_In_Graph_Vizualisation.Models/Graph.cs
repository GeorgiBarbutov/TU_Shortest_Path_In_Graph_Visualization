using System.Collections.Generic;

using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Graph : IGraph
    {
        private const float CENTER_X = 490f;
        private const float CENTER_Y = 195f;
        private const int DEFAULT_NODE_NUMBER = 1;
        private const bool DEFAULT_DESTINATION_IS_VISITED = false;

        private List<INode> nodes;

        public Graph()
        {
            this.Nodes = new List<INode>();
            this.CurrentNodeNumber = DEFAULT_NODE_NUMBER;
            this.Source = null;
            this.Destination = null;
            this.DestinationIsVisited = DEFAULT_DESTINATION_IS_VISITED;
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

        public INode DijkstraCurrentNode { get; private set; }

        public bool DestinationIsVisited { get; private set; }

        //Create a node from a already existing one and add it to the list of nodes.
        public INode AddExistingNode(int layer, int nodeNumber, float centerX, float centerY)
        {
            INode node = new Node(nodeNumber, layer, new Point(centerX, centerY));

            this.nodes.Add(node);

            return node;
        }

        //Create a new link and call AddLink method of the 2 nodes
        public ILink AddLink(INode node1, INode node2, int weight)
        {
            ILink link = new Link(node1, node2, weight);

            ((Node)node1).AddLink(link);
            ((Node)node2).AddLink(link);

            return link;
        }

        //Create a new node with the default center, add it to the list of nodes and increase the current node number.
        public INode AddNode(int layer)
        {
            INode node = new Node(this.CurrentNodeNumber, layer, new Point(CENTER_X, CENTER_Y));

            this.nodes.Add(node);

            this.CurrentNodeNumber += 1;

            return node;
        }

        //Create a new node with a specified center, add it to the list of nodes and increase the current node number.
        public INode AddNode(int layer, IPoint center)
        {
            INode node = new Node(this.CurrentNodeNumber, layer, center);

            this.nodes.Add(node);

            this.CurrentNodeNumber += 1;

            return node;
        }

        //Find a specified link and remove it from the 2 nodes lists of connected links
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

        //Remove a node from the list of nodes.
        //Than remove all links linked to than node from that and the other nodes lists of connected links
        public void RemoveNode(INode node)
        {
            this.nodes.Remove(node);

            int connectedLinks = node.ConnectedLinks.Count;

            for (int i = 0; i < connectedLinks; i++)
            {
                ILink link = node.ConnectedLinks[0];

                if (link.ConnectedNodes.Item1 == node)
                {
                    ((Node)link.ConnectedNodes.Item2).RemoveLink(link);
                }
                else
                {
                    ((Node)link.ConnectedNodes.Item1).RemoveLink(link);
                }

                ((Node)node).RemoveLink(link);
            } 
        }

        //Set destination is visited to false and current node to null
        public void Step0()
        {
            this.DestinationIsVisited = DEFAULT_DESTINATION_IS_VISITED;
            this.DijkstraCurrentNode = null;
        }

        //Foreach node in the list of nodes reset its parameters
        public void Step1()
        {
            foreach (INode node in this.Nodes)
            {
                node.ResetDjikstraParameters();
            }
        }

        //Set the source's destination from source to 0, set current node to the source node 
        public void Step2()
        {
            this.Source.DistanceFromSource = 0;

            this.DijkstraCurrentNode = this.Source;
        }

        //Find all connected nodes to the current node and if each of them is not visited find it's tenative distance.
        //If the tenative distance is less than it's current distance from source than distance from source becomes the tenative distance 
        //and it's previous node becomes the current node.
        public void Step3()
        {
            foreach (ILink link in this.DijkstraCurrentNode.ConnectedLinks)
            {
                INode otherNode;
                if (link.ConnectedNodes.Item1 == this.DijkstraCurrentNode)
                {
                    otherNode = link.ConnectedNodes.Item2;
                }
                else
                {
                    otherNode = link.ConnectedNodes.Item1;
                }

                if (!otherNode.IsVisited)
                {
                    int tentativeDistance = this.DijkstraCurrentNode.DistanceFromSource + link.Weight;

                    if (tentativeDistance < otherNode.DistanceFromSource)
                    {
                        otherNode.DistanceFromSource = tentativeDistance;
                        otherNode.PreviousNode = this.DijkstraCurrentNode;
                    }
                }
            }
        }

        //Set the current node as visited
        public void Step4()
        {
            this.DijkstraCurrentNode.IsVisited = true;
        }

        //Set the destination is visited
        public void Step5()
        {
            this.DestinationIsVisited = this.Destination.IsVisited;
        }

        //Take the node with the shortest distance from source that is not visited and set it as current node. 
        //Return false if no node is taken otherwise return true.
        public bool Step6()
        {
            int distanceFromSource = int.MaxValue;

            bool anyNodeIsTaken = false;

            foreach (INode node in this.Nodes)
            {
                if(!node.IsVisited && distanceFromSource > node.DistanceFromSource)
                {
                    distanceFromSource = node.DistanceFromSource;
                    this.DijkstraCurrentNode = node;

                    anyNodeIsTaken = true;
                }
            }

            return anyNodeIsTaken;
        }
    }
}
