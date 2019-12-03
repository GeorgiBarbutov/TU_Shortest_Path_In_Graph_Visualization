using System.Collections.Generic;
using System.Drawing;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface ILink
    {
        KeyValuePair<INode, INode> ConnectedNodes { get; }
        float Weight { get; }

        void Draw(Graphics graphics, Color color);
        bool Contains(PointF point);
    }
}
