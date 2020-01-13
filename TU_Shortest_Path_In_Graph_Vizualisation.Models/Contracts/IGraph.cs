using System.Collections.Generic;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface IGraph
    {
        int CurrentNodeNumber { get; }
        IReadOnlyList<INode> Nodes { get; }
        INode Source { get; set; }
        INode Destination { get; set; }

        INode AddNode(int layer);
        INode AddExistingNode(int layer, int nodeNumber, float centerX, float centerY);
        INode AddNode(int layer, IPoint center);
        ILink AddLink(INode node1, INode node2, int weight);
        void RemoveNode(INode node);
        void RemoveLink(ILink link);
    }
}
