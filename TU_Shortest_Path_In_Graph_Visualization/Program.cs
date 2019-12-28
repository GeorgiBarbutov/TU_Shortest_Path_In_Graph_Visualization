using System;
using System.Windows.Forms;

using TU_Shortest_Path_In_Graph_Visualization.IO;
using TU_Shortest_Path_In_Graph_Visualization.IO.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization
{
    //Link to repo in github: https://github.com/GeorgiBarbutov/TU_Shortest_Path_In_Graph_Visualization
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IGraph graph = new Graph();
            IExporter exporter = new Exporter();
            IImporter importer = new Importer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GraphCreator(graph, exporter, importer));
        }
    }
}
