﻿using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization.IO.Contracts
{
    public interface IImporter
    {
        IGraph Import(string path, out int currentMaxLayer);
    }
}
