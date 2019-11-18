using System;
using System.Collections.Generic;
using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Node : INode
    {
        private const float NODE_SIZE = 50f;
        private const string LINK_NULL = "Failed to connect link with node";
        private const string NEGATIVE_LAYER = "Negative layer not permited";

        public Node(int nodeNumber, int layer, KeyValuePair<float, float> center)
        {
            this.NodeNumber = nodeNumber;
            this.Layer = layer;
            this.ConnectedLinks = new List<ILink>();
            this.Center = center;
        }

        public int NodeNumber { get; private set; }

        public int Layer { get; private set; }

        public List<ILink> ConnectedLinks { get; private set; }

        public KeyValuePair<float, float> Center { get; private set; }

        public void AddLink(ILink link)
        {
            if(link == null)
            {
                throw new ArgumentNullException("link", LINK_NULL);
            }

            this.ConnectedLinks.Add(link);
        }

        public void ChangeCurrentLayer(int newLayer)
        {
            if (newLayer < 0)
            {
                throw new ArgumentException(NEGATIVE_LAYER);
            }

            this.Layer = newLayer;
        }

        public bool Contains(PointF point)
        {
            //TODO:
            return false;
        }

        public void Draw(Graphics graphics)
        {
            //TODO:
        }

        public void Move(float xOffset, float yOffset)
        {
            //TODO:
        }

        public void Outline(Graphics graphics, Color color)
        {
            //TODO:
        }
    }
}
