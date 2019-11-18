using System.Collections.Generic;
using System.Drawing;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface INode
    {
        int NodeNumber { get; }
        int Layer { get; }
        List<ILink> ConnectedLinks { get; }
        KeyValuePair<float, float> Center { get; }

        void Move(float xOffset, float yOffset);
        bool Contains(PointF point);
        void Outline(Graphics graphics, Color color);
        void ChangeCurrentLayer(int newLayer);
        void Draw(Graphics graphics);
        void AddLink(ILink link);
    }
}
