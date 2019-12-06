using System;
using System.Drawing;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface ILink
    {
        Tuple<INode, INode> ConnectedNodes { get; }
        int Weight { get; }

        void Draw(Graphics graphics, Color color);
        bool Contains(PointF point);
        void ChangeWeight(int newWeight);
    }
}
