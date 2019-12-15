using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Drawing
{
    public class NodeDraw : INodeDraw
    {
        private const string NUMBER_FONT = "Arial";
        private const int NUMBER_SIZE = 10;
        private const int NUMBER_CENTER_OFFSET = 7;
        private const int TENATIVE_VALUE_HEIGHT_OFFSET = 45;
        private const float OUTLINE_WIDTH = 2f;
        private const float NODE_SIZE = 20f;

        public NodeDraw(INode node)
        {
            this.Node = node;
        }

        public INode Node { get; private set; }

        public void Draw(Graphics graphics, Color color)
        {
            Brush brush = new SolidBrush(Color.White);

            graphics.FillEllipse(brush, this.Node.Center.X - NODE_SIZE, this.Node.Center.Y - NODE_SIZE,
                NODE_SIZE * 2, NODE_SIZE * 2);

            brush.Dispose();

            Outline(graphics, color);
            DrawNodeNumber(graphics, color);
        }

        private void Outline(Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, OUTLINE_WIDTH);

            graphics.DrawEllipse(pen, this.Node.Center.X - NODE_SIZE, this.Node.Center.Y - NODE_SIZE,
                NODE_SIZE * 2, NODE_SIZE * 2);

            pen.Dispose();
        }

        private void DrawNodeNumber(Graphics graphics, Color color)
        {
            Font font = new Font(NUMBER_FONT, NUMBER_SIZE);
            Brush brush = new SolidBrush(color);

            graphics.DrawString(this.Node.NodeNumber.ToString(), font, brush, this.Node.Center.X - NUMBER_CENTER_OFFSET,
                this.Node.Center.Y - NUMBER_CENTER_OFFSET);

            font.Dispose();
            brush.Dispose();
        }

        public void DrawTenativeValue(Graphics graphics, Color color)
        {
            Font font = new Font(NUMBER_FONT, NUMBER_SIZE);
            Brush brush = new SolidBrush(color);

            string displayTenativeValue = this.Node.DistanceFromSource.ToString();

            if (this.Node.DistanceFromSource == int.MaxValue)
            {
                displayTenativeValue = "\u221E";
            }

            graphics.DrawString(displayTenativeValue, font, brush, this.Node.Center.X - NUMBER_CENTER_OFFSET, 
                this.Node.Center.Y - TENATIVE_VALUE_HEIGHT_OFFSET);

            font.Dispose();
            brush.Dispose();
        }
    }
}
