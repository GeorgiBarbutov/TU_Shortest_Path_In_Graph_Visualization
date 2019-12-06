using System;
using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Link : ILink
    {
        private const float OUTLINE_WIDTH = 2f;
        private const string NUMBER_FONT = "Arial";
        private const int NUMBER_SIZE = 10;
        private const int NUMBER_CENTER_OFFSET = 20;

        public Link(INode node1, INode node2, int weight)
        {
            this.Weight = weight;
            this.ConnectedNodes = new Tuple<INode, INode>(node1, node2);
        }

        public Tuple<INode, INode> ConnectedNodes { get; private set; }

        public int Weight { get; private set; }

        public void ChangeWeight(int newWeight)
        {
            this.Weight = newWeight;
        }

        public bool Contains(PointF point)
        {
            double x1 = this.ConnectedNodes.Item1.Center.X;
            double y1 = this.ConnectedNodes.Item1.Center.Y;
            double x2 = this.ConnectedNodes.Item2.Center.X;
            double y2 = this.ConnectedNodes.Item2.Center.Y;
            double m = (y2 - y1) / (x2 - x1);
            //y = mx + b => b = y - mx
            double b = y1 - (m * x1);
            
            return point.Y >= Math.Floor((m * point.X) + b) - 3 && 
                point.Y <= Math.Floor((m * point.X) + b) + 3 && 
                point.X >= Math.Min(x1, x2) && 
                point.X <= Math.Max(x1, x2) &&
                point.Y >= Math.Min(y1, y2) &&
                point.Y <= Math.Max(y1, y2);
        }

        public void Draw(Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, OUTLINE_WIDTH);

            graphics.DrawLine(pen, this.ConnectedNodes.Item1.Center.X, this.ConnectedNodes.Item1.Center.Y, 
                this.ConnectedNodes.Item2.Center.X, this.ConnectedNodes.Item2.Center.Y);

            pen.Dispose();

            DrawWeight(graphics, color);
        }

        private void DrawWeight(Graphics graphics, Color color)
        {
            Font font = new Font(NUMBER_FONT, NUMBER_SIZE);
            Brush brush = new SolidBrush(color);

            float centerX = (this.ConnectedNodes.Item1.Center.X + this.ConnectedNodes.Item2.Center.X) / 2;
            float centerY = (this.ConnectedNodes.Item1.Center.Y + this.ConnectedNodes.Item2.Center.Y) / 2;

            graphics.DrawString(this.Weight.ToString(), font, brush, centerX - NUMBER_CENTER_OFFSET,
                centerY - NUMBER_CENTER_OFFSET);

            font.Dispose();
            brush.Dispose();
        }
    }
}
