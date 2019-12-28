using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TU_Shortest_Path_In_Graph_Vizualisation.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization
{
    public partial class DijkstraAlgorithm : Form
    {
        private const int DEFAULT_CURRENT_STEP = 0;
        private const bool DEFAULT_IS_FINISHED = false;
        private const int MAX_UN_VISITED_NODES_TEXT = 14;

        private static readonly string[] stepText = new string[] { " Step 1: Set all nodes as unvisited. Set the distance to the source of all nodes to infinity. Set previous node of all nodes to null.", "Step 2: Set the distance to source of the source node to 0. Set the source node as current node", "Step 3: For the current node, consider all of its unvisited neighbours and calculate their tentative distances through the current node.\nCompare the newly calculated tentative distance to the current assigned value and assign the smaller one.\nIf a new value is assigned change previous node to the current node.", "Step 4: Set the current node as visited and remove it from the unvisited list. A visited node will never be checked again." , "Step 5: If the destination node has been set to visited than stop the algorithm." , "Step 6: Otherwise, select the unvisited node that is marked with the smallest tentative distance, set it as the new current node, \nand go back to step 3." , "Final Step: After the end trace back through the previous nodes starting from the destination and ending with the source. \nThat is your shortest path." };

        private readonly IGraph graph;
        private Graphics graphics;
        private int currentStep;
        private bool isFinished;

        public DijkstraAlgorithm(IGraph graph)
        {
            InitializeComponent();

            this.graph = graph;
            this.currentStep = DEFAULT_CURRENT_STEP;
            this.isFinished = DEFAULT_IS_FINISHED;

            this.graph.Step0();

            this.graphics = this.Visualization.CreateGraphics();
        }

        //Draws all the links, then draws all the noodes, then draws tenative values if the current step is one or more. 
        public void DrawPanel()
        {
            this.Visualization.Refresh();

            foreach (INode node in this.graph.Nodes.OrderBy(n => n.Layer))
            {
                foreach (ILink link in node.ConnectedLinks)
                {
                    ILinkDraw linkDraw = new LinkDraw(link);

                    linkDraw.Draw(this.graphics, Color.Black);
                }
            }

            foreach (INode node in this.graph.Nodes.OrderBy(n => n.Layer))
            {
                INodeDraw nodeDraw = new NodeDraw(node);

                if (this.graph.DijkstraCurrentNode == node)
                {
                    nodeDraw.Draw(this.graphics, Color.Red);
                }
                else if (node == this.graph.Source)
                {
                    nodeDraw.Draw(this.graphics, Color.Blue);
                }
                else if (node == this.graph.Destination)
                {
                    nodeDraw.Draw(this.graphics, Color.Green);
                }
                else
                {
                    nodeDraw.Draw(this.graphics, Color.Black);
                }

                if(this.currentStep >= 1)
                {
                    nodeDraw.DrawTenativeValue(this.graphics, Color.Magenta);
                }
            }
        }

        //if the algorithm isn't finished increses current step and updates labels and executes code for the specific step. 
        //After it's finished gets the shortest path.
        //Step1();
        //Step2();
        //while (true)
        //{
        //    Step3();
        //    Step4();
        //    Step5(); // true -> break; false -> step6();
        //    Step6(); //Step 6 -> Step 3
        //}
        //Step7();
        private void NextStepButton_Click(object sender, System.EventArgs e)
        {
            if (!this.isFinished)
            {
                this.currentStep += 1;

                if (this.currentStep == 1)
                {
                    this.StepsLabel.Text = stepText[this.currentStep - 1];

                    this.graph.Step1();

                    UpdateUnvisitedList();

                    DrawPanel();
                } 
                else if (this.currentStep == 2)
                {
                    this.StepsLabel.Text = stepText[this.currentStep - 1];

                    this.graph.Step2();

                    this.CurrentNodeLabel.Text = $"Current Node: {this.graph.DijkstraCurrentNode.NodeNumber}";

                    DrawPanel();
                }
                else if (this.currentStep == 3)
                {
                    this.StepsLabel.Text = stepText[this.currentStep - 1];

                    this.graph.Step3();

                    DrawPanel();

                    UpdateUnvisitedList();
                }
                else if (this.currentStep == 4)
                {
                    this.StepsLabel.Text = stepText[this.currentStep - 1];

                    this.graph.Step4();

                    UpdateUnvisitedList();
                    UpdateVisitedList();
                }
                else if (this.currentStep == 5)
                {
                    this.StepsLabel.Text = stepText[this.currentStep - 1];

                    this.graph.Step5();

                    if(this.graph.DestinationIsVisited)
                    {
                        this.isFinished = true;
                    }
                }
                else if (this.currentStep == 6)
                {
                    this.StepsLabel.Text = stepText[this.currentStep - 1];

                    this.graph.Step6();

                    this.CurrentNodeLabel.Text = $"Current Node: {this.graph.DijkstraCurrentNode.NodeNumber}";

                    DrawPanel();

                    this.currentStep = 2;
                }
            }
            else
            {
                this.StepsLabel.Text = stepText[this.currentStep + 1];
                this.ShortestPathLabel.Text = GetShortestPath();
            }
        }

        //Navigates through all previous nodes starting from the destination and ending with source and then reverses the path
        private string GetShortestPath()
        {
            INode previousNode = this.graph.DijkstraCurrentNode;

            List<string> nodes = new List<string>();

            while (previousNode != null)
            {
                nodes.Add(previousNode.NodeNumber.ToString());
                previousNode = previousNode.PreviousNode;
            }

            nodes.Reverse();

            return String.Join(" -> ", nodes);
        }

        //Finds all unvisited nodes and then transfers their data into a string
        private void UpdateUnvisitedList()
        {
            string[] unvisitedStrings = this.graph.Nodes
                .Where(n => !n.IsVisited)
                .Select(n => n.PreviousNode == null ? $"({n.NodeNumber.ToString()}, -)" : $"({n.NodeNumber.ToString()}, {n.PreviousNode.NodeNumber})")
                .ToArray();

            if (unvisitedStrings.Length > MAX_UN_VISITED_NODES_TEXT)
            {
                this.UnvisitedLabel.Text = $"Unvisited: [ {String.Join(", ", unvisitedStrings.Take(MAX_UN_VISITED_NODES_TEXT))}, ... ]";
            }
            else
            {
                this.UnvisitedLabel.Text = $"Unvisited: [ {String.Join(", ", unvisitedStrings)} ]";
            }
        }

        //Finds all visited nodes and then transfers their data into a string
        private void UpdateVisitedList()
        {
            string[] visitedStrings = this.graph.Nodes
                .Where(n => n.IsVisited)
                .Select(n => n.PreviousNode == null ? $"({n.NodeNumber.ToString()}, -)" : $"({n.NodeNumber.ToString()}, {n.PreviousNode.NodeNumber})")
                .ToArray();

            if (visitedStrings.Length > MAX_UN_VISITED_NODES_TEXT)
            {
                this.VisitedLabel.Text = $"Visited: [ {String.Join(", ", visitedStrings.Take(MAX_UN_VISITED_NODES_TEXT))}, ... ]";
            }
            else
            {
                this.VisitedLabel.Text = $"Visited: [ {String.Join(", ", visitedStrings)} ]";
            }
        }

        //Disposes of graphics and then of the form itself
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.graphics.Dispose();

            this.Dispose();
        }

        //On loading changes the legend label text
        private void DijkstraAlgorithm_Load(object sender, EventArgs e)
        {
            this.LegendLabel.Text = "Legend:\n\nBlue Node - Source\nGreen Node - Destination\nRed Node - Current Node\nUn/visited Nodes - (<nodeNumber>, <previousNode>)";
        }
    }
}
