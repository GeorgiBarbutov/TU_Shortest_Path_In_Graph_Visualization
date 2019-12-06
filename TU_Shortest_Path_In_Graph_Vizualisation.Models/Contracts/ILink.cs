using System;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface ILink
    {
        Tuple<INode, INode> ConnectedNodes { get; }
        int Weight { get; }

        bool Contains(IPoint point);
        void ChangeWeight(int newWeight);
    }
}
