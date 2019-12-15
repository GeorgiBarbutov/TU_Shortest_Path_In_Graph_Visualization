namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface IDijkstraSteps
    {
        INode DijkstraCurrentNode { get; }
        bool DestinationIsVisited { get; }

        void Step1();
        void Step2();
        void Step3();
        void Step4();
        void Step5();
        void Step6();
    }
}
