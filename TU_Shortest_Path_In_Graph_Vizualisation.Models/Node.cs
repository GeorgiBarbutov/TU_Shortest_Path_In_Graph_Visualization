using System;
using System.Collections.Generic;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Node : INode
    {
        private const float NODE_SIZE = 20f;
        private const string NEGATIVE_LAYER = "Negative layer not permited";

        private List<ILink> connectedLinks;

        public Node(int nodeNumber, int layer, IPoint center)
        {
            this.NodeNumber = nodeNumber;
            this.Layer = layer;
            this.ConnectedLinks = new List<ILink>();
            this.Center = center;
        }

        public int NodeNumber { get; private set; }

        public int Layer { get; private set; }

        public IReadOnlyList<ILink> ConnectedLinks {
            get => this.connectedLinks;
            private set => this.connectedLinks = (List<ILink>)value;
        }

        public IPoint Center { get; private set; }

        internal void AddLink(ILink link)
        {
            this.connectedLinks.Add(link);
        }

        internal void RemoveLink(ILink link)
        {
            this.connectedLinks.Remove(link);
        }

        public void ChangeCurrentLayer(int newLayer)
        {
            if (newLayer < 0)
            {
                throw new ArgumentException(NEGATIVE_LAYER);
            }

            this.Layer = newLayer;
        }

        public bool Contains(IPoint point)
        {
            if ((point.X - this.Center.X) * (point.X - this.Center.X) +
                (point.Y - this.Center.Y) * (point.Y - this.Center.Y) <= NODE_SIZE * NODE_SIZE)
                return true;
            else
                return false;
        }

        public void Move(float xOffset, float yOffset)
        {
            this.Center = new Point(this.Center.X + xOffset, this.Center.Y + yOffset);
        }
    }
}
