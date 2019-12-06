using System.Collections.Generic;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface INode
    {
        int NodeNumber { get; }
        int Layer { get; }
        IReadOnlyList<ILink> ConnectedLinks { get; }
        IPoint Center { get; }

        void Move(float xOffset, float yOffset);
        bool Contains(IPoint point);
        void ChangeCurrentLayer(int newLayer);
    }
}
