using System.Drawing;

using TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Drawing
{
    public class NodeDraw : INodeDraw
    {
        private const string NUMBER_FONT = "Arial";
        private const int NUMBER_SIZE = 10;
        private const int NUMBER_CENTER_OFFSET = 10;
        private const int TENATIVE_VALUE_HEIGHT_OFFSET = 45;
        private const float OUTLINE_WIDTH = 2f;
        private const float NODE_SIZE = 20f;

        public NodeDraw(INode node)
        {
            this.Node = node;
        }

        public INode Node { get; private set; }

        //Create a Brush object and draw a circle with a specified center in white. Then outline it and draw the node number.
        public void Draw(Graphics graphics, Color color)
        {
            Brush brush = new SolidBrush(Color.White);

            graphics.FillEllipse(brush, this.Node.Center.X - NODE_SIZE, this.Node.Center.Y - NODE_SIZE,
                NODE_SIZE * 2, NODE_SIZE * 2);

            brush.Dispose();

            Outline(graphics, color);
            DrawNodeNumber(graphics, color);
        }

        //Create a pen object and draw a circle outline with a specified color
        private void Outline(Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, OUTLINE_WIDTH);

            graphics.DrawEllipse(pen, this.Node.Center.X - NODE_SIZE, this.Node.Center.Y - NODE_SIZE,
                NODE_SIZE * 2, NODE_SIZE * 2);

            pen.Dispose();
        }


        //Create a font and a brush object and draw the number in the center of the circle
        private void DrawNodeNumber(Graphics graphics, Color color)
        {
            Font font = new Font(NUMBER_FONT, NUMBER_SIZE);
            Brush brush = new SolidBrush(color);

            graphics.DrawString(this.Node.NodeNumber.ToString(), font, brush, this.Node.Center.X - NUMBER_CENTER_OFFSET,
                this.Node.Center.Y - NUMBER_CENTER_OFFSET);

            font.Dispose();
            brush.Dispose();
        }

        //Create a fFont and a Brush object than draw the tenative value just above the node. 
        //If the value is int.Max than draw a infinity sign
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
