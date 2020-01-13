using TU_Shortest_Path_In_Graph_Dijkstra.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Dijkstra
{
    public class Dijkstra : IDijkstra
    {
        private const bool DEFAULT_DESTINATION_IS_VISITED = false;

        public Dijkstra(IGraph graph)
        {
            this.Graph = graph;
        }

        public INode DijkstraCurrentNode { get; private set; }

        public bool DestinationIsVisited { get; private set; }

        public IGraph Graph { get; private set; }

        //Set destination is visited to false and current node to null
        public void Step0()
        {
            this.DestinationIsVisited = DEFAULT_DESTINATION_IS_VISITED;
            this.DijkstraCurrentNode = null;
        }

        //Foreach node in the list of nodes reset its parameters
        public void Step1()
        {
            foreach (INode node in this.Graph.Nodes)
            {
                node.ResetDjikstraParameters();
            }
        }

        //Set the source's destination from source to 0, set current node to the source node 
        public void Step2()
        {
            this.Graph.Source.DistanceFromSource = 0;

            this.DijkstraCurrentNode = this.Graph.Source;
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
            this.DestinationIsVisited = this.Graph.Destination.IsVisited;
        }

        //Take the node with the shortest distance from source that is not visited and set it as current node. 
        //Return false if no node is taken otherwise return true.
        public bool Step6()
        {
            int distanceFromSource = int.MaxValue;

            bool anyNodeIsTaken = false;

            foreach (INode node in this.Graph.Nodes)
            {
                if (!node.IsVisited && distanceFromSource > node.DistanceFromSource)
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
