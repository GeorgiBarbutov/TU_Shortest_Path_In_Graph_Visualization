using System;
using System.Collections.Generic;
using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Node : INode
    {
        private const float NODE_SIZE = 20f;
        private const string NUMBER_FONT = "Arial";
        private const int NUMBER_SIZE = 10;
        private const int NUMBER_CENTER_OFFSET = 7;
        private const float OUTLINE_WIDTH = 2f;
        private const string NEGATIVE_LAYER = "Negative layer not permited";

        private List<ILink> connectedLinks;

        public Node(int nodeNumber, int layer, PointF center)
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

        public PointF Center { get; private set; }

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

        public bool Contains(PointF point)
        {
            if ((point.X - this.Center.X) * (point.X - this.Center.X) +
                (point.Y - this.Center.Y) * (point.Y - this.Center.Y) <= NODE_SIZE * NODE_SIZE)
                return true;
            else
                return false;
        }

        public void Draw(Graphics graphics, Color color)
        {
            Brush brush = new SolidBrush(Color.White);

            graphics.FillEllipse(brush, this.Center.X - NODE_SIZE, this.Center.Y - NODE_SIZE,
                NODE_SIZE * 2, NODE_SIZE * 2);

            brush.Dispose();

            Outline(graphics, color);
            DrawNodeNumber(graphics, color);
        }

        private void DrawNodeNumber(Graphics graphics, Color color)
        {
            Font font = new Font(NUMBER_FONT, NUMBER_SIZE);
            Brush brush = new SolidBrush(color);

            graphics.DrawString(this.NodeNumber.ToString(), font, brush, this.Center.X - NUMBER_CENTER_OFFSET,
                this.Center.Y - NUMBER_CENTER_OFFSET);

            font.Dispose();
            brush.Dispose();
        }

        public void Move(float xOffset, float yOffset)
        {
            this.Center = new PointF(this.Center.X + xOffset, this.Center.Y + yOffset);
        }

        public void Outline(Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, OUTLINE_WIDTH);

            graphics.DrawEllipse(pen, this.Center.X - NODE_SIZE, this.Center.Y - NODE_SIZE,
                NODE_SIZE * 2, NODE_SIZE * 2);

            pen.Dispose();
        }
    }
}
