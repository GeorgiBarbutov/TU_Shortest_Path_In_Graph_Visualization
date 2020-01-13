using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Dijkstra.Contracts
{
    public interface IDijkstra
    {
        INode DijkstraCurrentNode { get; }
        bool DestinationIsVisited { get; }
        IGraph Graph { get; }

        void Step0();
        void Step1();
        void Step2();
        void Step3();
        void Step4();
        void Step5();
        bool Step6();
    }
}
