using System;
using System.Collections.Generic;

using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Node : INode
    {
        public const float NODE_SIZE = 20f;
        private const string NEGATIVE_LAYER = "Negative layer not permited";

        private List<ILink> connectedLinks;

        public Node(int nodeNumber, int layer, IPoint center)
        {
            this.NodeNumber = nodeNumber;
            this.Layer = layer;
            this.ConnectedLinks = new List<ILink>();
            this.Center = center;
            this.ResetDjikstraParameters();
        }

        public int NodeNumber { get; private set; }

        public int Layer { get; private set; }

        public IReadOnlyList<ILink> ConnectedLinks {
            get => this.connectedLinks;
            private set => this.connectedLinks = (List<ILink>)value;
        }

        public IPoint Center { get; private set; }

        public bool IsVisited { get; set; }

        public INode PreviousNode { get; set; }

        public int DistanceFromSource { get; set; }

        //Adds link to connected links list
        internal void AddLink(ILink link)
        {
            this.connectedLinks.Add(link);
        }

        //Removes link to connected links list
        internal void RemoveLink(ILink link)
        {
            this.connectedLinks.Remove(link);
        }

        //Changes current layer if the value is non negative
        public void ChangeCurrentLayer(int newLayer)
        {
            if (newLayer < 0)
            {
                throw new ArgumentException(NEGATIVE_LAYER);
            }

            this.Layer = newLayer;
        }

        //Checks if a point is inside or on the node 
        public bool Contains(IPoint point)
        {
            if ((point.X - this.Center.X) * (point.X - this.Center.X) +
                (point.Y - this.Center.Y) * (point.Y - this.Center.Y) <= NODE_SIZE * NODE_SIZE)
                return true;
            else
                return false;
        }

        //Changes the values of the center by a given offset
        public void Move(float xOffset, float yOffset)
        {
            this.Center = new Point(this.Center.X + xOffset, this.Center.Y + yOffset);
        }

        //Resets values important for Dijkstra Algorithm
        public void ResetDjikstraParameters()
        {
            this.IsVisited = false;
            this.DistanceFromSource = int.MaxValue;
            this.PreviousNode = null;
        }
    }
}
