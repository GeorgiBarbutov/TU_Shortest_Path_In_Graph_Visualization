﻿using System.Collections.Generic;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface IGraph
    {
        int CurrentNodeNumber { get; }
        IReadOnlyList<INode> Nodes { get; }

        INode AddNode(int layer);
        ILink AddLink(INode node1, INode node2, int weight);
        void RemoveNode(INode node);
        void RemoveLink(ILink link);
    }
}