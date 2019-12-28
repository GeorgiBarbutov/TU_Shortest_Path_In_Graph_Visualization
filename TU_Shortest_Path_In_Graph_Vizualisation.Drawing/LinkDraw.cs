using System.Drawing;

using TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Drawing
{
    public class LinkDraw : ILinkDraw
    {
        private const float OUTLINE_WIDTH = 2f;
        private const string NUMBER_FONT = "Arial";
        private const int NUMBER_SIZE = 10;
        private const int NUMBER_CENTER_OFFSET = 20;

        public LinkDraw(ILink link)
        {
            this.Link = link;
        }

        public ILink Link { get; private set; }

        //Create a Pen object, draw a line between the centers of the two connected nodes and than draw the weight number
        public void Draw(Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, OUTLINE_WIDTH);

            graphics.DrawLine(pen, this.Link.ConnectedNodes.Item1.Center.X, this.Link.ConnectedNodes.Item1.Center.Y,
                this.Link.ConnectedNodes.Item2.Center.X, this.Link.ConnectedNodes.Item2.Center.Y);

            pen.Dispose();

            DrawWeight(graphics, color);
        }

        //Create a Font and a Brush object and draw the number just above the middle of the line
        private void DrawWeight(Graphics graphics, Color color)
        {
            Font font = new Font(NUMBER_FONT, NUMBER_SIZE);
            Brush brush = new SolidBrush(color);

            float centerX = (this.Link.ConnectedNodes.Item1.Center.X + this.Link.ConnectedNodes.Item2.Center.X) / 2;
            float centerY = (this.Link.ConnectedNodes.Item1.Center.Y + this.Link.ConnectedNodes.Item2.Center.Y) / 2;

            graphics.DrawString(this.Link.Weight.ToString(), font, brush, centerX - NUMBER_CENTER_OFFSET,
                centerY - NUMBER_CENTER_OFFSET);

            font.Dispose();
            brush.Dispose();
        }
    }
}
