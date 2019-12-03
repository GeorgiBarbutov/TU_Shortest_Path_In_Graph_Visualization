using System.Collections.Generic;
using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Link : ILink
    {
        private const float OUTLINE_WIDTH = 2f;

        public Link(INode node1, INode node2, float weight)
        {
            this.Weight = weight;
            this.ConnectedNodes = new KeyValuePair<INode, INode>(node1, node2);
        }

        public KeyValuePair<INode, INode> ConnectedNodes { get; private set; }

        public float Weight { get; private set; }

        public bool Contains(PointF point)
        {
            //TODO:

            return false;
        }

        public void Draw(Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, OUTLINE_WIDTH);

            graphics.DrawLine(pen, this.ConnectedNodes.Key.Center.X, this.ConnectedNodes.Key.Center.Y, 
                this.ConnectedNodes.Value.Center.X, this.ConnectedNodes.Value.Center.Y);

            pen.Dispose();
        }
    }
}
