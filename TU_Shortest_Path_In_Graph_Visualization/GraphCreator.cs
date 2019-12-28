using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TU_Shortest_Path_In_Graph_Visualization.IO.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

using Point = TU_Shortest_Path_In_Graph_Vizualisation.Models.Point;

namespace TU_Shortest_Path_In_Graph_Visualization
{
    public partial class GraphCreator : Form
    {
        private const int DEFAULT_CURRENT_MAX_LAYER = 0;
        private const int MINIMUM_RANDOM_WEIGHT = 1;
        private const int MAXIMUM_RANDOM_WEIGHT = 50;

        private IGraph graph;
        private INodeDraw selectedNode;
        private ILinkDraw selectedLink;
        private int currentMaxLayer;
        private readonly Graphics graphics;
        private int mouseDownXCoordinate;
        private int mouseDownYCoordinate;
        private readonly IExporter exporter;
        private readonly IImporter importer;
        private INodeDraw source;
        private INodeDraw destination;

        public GraphCreator(IGraph graph, IExporter exporter, IImporter importer)
        {
            InitializeComponent();

            this.graph = graph;
            this.exporter = exporter;
            this.importer = importer;
            this.selectedLink = null;
            this.selectedNode = null;
            this.currentMaxLayer = DEFAULT_CURRENT_MAX_LAYER;
            this.source = null;
            this.destination = null;

            this.graphics = this.Visualization.CreateGraphics();
        }

        //Draws all the links then all the nodes
        private void RedrawPanel()
        {
            this.Visualization.Refresh();

            foreach (INode node in this.graph.Nodes.OrderBy(n => n.Layer))
            {
                foreach (ILink link in node.ConnectedLinks)
                {
                    ILinkDraw linkDraw = new LinkDraw(link);

                    if (this.selectedLink != null && link == this.selectedLink.Link)
                    {
                        linkDraw.Draw(this.graphics, Color.Red);
                    }
                    else
                    {
                        linkDraw.Draw(this.graphics, Color.Black);
                    }
                }
            }

            foreach (INode node in this.graph.Nodes.OrderBy(n => n.Layer))
            {
                INodeDraw nodeDraw = new NodeDraw(node);

                if (this.selectedNode != null && node == this.selectedNode.Node)
                {
                    nodeDraw.Draw(this.graphics, Color.Red);
                }
                else if (this.source != null && node == this.source.Node)
                {
                    nodeDraw.Draw(this.graphics, Color.Blue);
                }
                else if (this.destination != null && node == this.destination.Node)
                {
                    nodeDraw.Draw(this.graphics, Color.Green);
                }
                else
                {
                    nodeDraw.Draw(this.graphics, Color.Black);
                }
            }
        }

        //Resets link related values
        private void DeselectLink()
        {
            this.selectedLink = null;
            this.Node1NumericUpDown.Value = 0;
            this.Node2NumericUpDown.Value = 0;
            this.WeightNumericUpDown.Value = 0;
        }

        //Increases current max layer, calles AddNode method in graph, deselects node and link and redraws panel.
        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            this.currentMaxLayer += 1;

            this.graph.AddNode(this.currentMaxLayer);

            this.selectedNode = null;
            DeselectLink();

            RedrawPanel();
        }

        //If a node is selected -> calles remove node method in graph.
        //Than resets source and destination and selected node if any, redraws panel.
        private void RemoveNodeButton_Click(object sender, EventArgs e)
        {
            if (this.selectedNode != null)
            {
                this.graph.RemoveNode(this.selectedNode.Node);

                if (this.source != null && this.selectedNode.Node == this.source.Node)
                {
                    this.graph.Source = null;
                    this.source = null;
                }

                if (this.destination != null && this.selectedNode.Node == this.destination.Node)
                {
                    this.graph.Destination = null;
                    this.destination = null;
                }

                this.selectedNode = null;

                RedrawPanel();
            }
        }

        //If a mouse button is presed saves coordinates of cursor. 
        //If its the left mouse button visually deselect link or node if any.
        //Than check if cursor is on any node.
        //If true than increase current layer, deselect link, set node to selected node change its layer and redraw it in red.
        //If false then check if currsor is on any link
        //If true then deselect node, set link as selected link, redraw it and set its values from input.
        //If cursor is not on any link or node then deselect currently selected node and link if any
        private void Visualization_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownXCoordinate = e.X;
            this.mouseDownYCoordinate = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                IPoint cursorPosition = new Point(e.X, e.Y);

                if (this.selectedNode != null)
                {
                    if (this.source != null && this.selectedNode.Node == this.source.Node)
                    {
                        this.selectedNode.Draw(this.graphics, Color.Blue);
                    }
                    else if (this.destination != null && this.selectedNode.Node == this.destination.Node)
                    {
                        this.selectedNode.Draw(this.graphics, Color.Green);
                    }
                    else
                    {
                        this.selectedNode.Draw(this.graphics, Color.Black);
                    }
                }

                if (this.selectedLink != null)
                {
                    this.selectedLink.Draw(this.graphics, Color.Black);
                }

                bool cursorIsOnAnyLinkOrNode = false;

                foreach (INode node in this.graph.Nodes.OrderByDescending(n => n.Layer))
                {
                    bool isInsideNode = node.Contains(cursorPosition);

                    if (isInsideNode)
                    {
                        this.currentMaxLayer += 1;

                        this.selectedNode = new NodeDraw(node);
                        DeselectLink();

                        this.selectedNode.Node.ChangeCurrentLayer(this.currentMaxLayer);

                        this.selectedNode.Draw(this.graphics, Color.Red);

                        cursorIsOnAnyLinkOrNode = true;

                        break;
                    }
                }
                if (!cursorIsOnAnyLinkOrNode)
                {
                    foreach (INode node in this.graph.Nodes)
                    {
                        foreach (ILink link in node.ConnectedLinks)
                        {
                            bool isInsideLink = link.Contains(cursorPosition);

                            if (isInsideLink)
                            {
                                this.selectedLink = new LinkDraw(link);
                                this.selectedNode = null;

                                this.selectedLink.Draw(this.graphics, Color.Red);

                                this.Node1NumericUpDown.Value = this.selectedLink.Link.ConnectedNodes.Item1.NodeNumber;
                                this.Node2NumericUpDown.Value = this.selectedLink.Link.ConnectedNodes.Item2.NodeNumber;
                                this.WeightNumericUpDown.Value = this.selectedLink.Link.Weight;

                                cursorIsOnAnyLinkOrNode = true;

                                break;
                            }
                        }

                        if(cursorIsOnAnyLinkOrNode)
                        {
                            break;
                        }
                    }
                }

                if(!cursorIsOnAnyLinkOrNode)
                {
                    this.selectedNode = null;
                    DeselectLink();
                }
            }
        }

        //Redraws panel
        private void Visualization_MouseUp(object sender, MouseEventArgs e)
        {
            RedrawPanel();
        }

        //If there is a selected node and the left mouse button is pressed and we move the mouse we visually move and redraw node
        private void Visualization_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.selectedNode != null && e.Button == MouseButtons.Left)
            {
                this.selectedNode.Draw(this.graphics, Color.White);

                this.selectedNode.Node.Move(e.X - this.mouseDownXCoordinate, e.Y - this.mouseDownYCoordinate);

                this.selectedNode.Draw(this.graphics, Color.Red);

                this.mouseDownXCoordinate = e.X;
                this.mouseDownYCoordinate = e.Y;
            }
        }

        //Check if inputed nodes both exist and are different and a link doesn't already exist between them.
        //If true call AddLink method in graph and redraw panel.
        private void AddLinkButton_Click(object sender, EventArgs e)
        {
            INode node1 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node1NumericUpDown.Value);
            INode node2 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node2NumericUpDown.Value);

            if(node1 != null && node2 != null && node1 != node2)
            {
                bool linkExists = node1.ConnectedLinks.Any(l => 
                    (l.ConnectedNodes.Item1 == node1 && l.ConnectedNodes.Item2 == node2) || 
                    (l.ConnectedNodes.Item2 == node1 && l.ConnectedNodes.Item1 == node2));

                if(!linkExists)
                {
                    this.graph.AddLink(node1, node2, (int)this.WeightNumericUpDown.Value);

                    this.selectedNode = null;
                    DeselectLink();

                    RedrawPanel();
                }
            }
        }

        //If a link is selected deselect it and then call RemoveLink method in graph. Than redraw the panel.
        private void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            if (this.selectedLink != null)
            {
                this.graph.RemoveLink(this.selectedLink.Link);

                DeselectLink();

                RedrawPanel();
            }
        }

        //If there is a selected link check if inputed nodes both exist and are different 
        //and a link doesn't already exist between them.
        //If it doesn't call RemoveLink in graph with than call AddLink method in graph and set it as the selected link 
        //and redraw panel.
        //If a link already exists then check if new and old weights are different. 
        //If they are change the weight and redraw panel.
        private void EditLinkButton_Click(object sender, EventArgs e)
        {
            if(this.selectedLink != null)
            {
                INode newNode1 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node1NumericUpDown.Value);
                INode newNode2 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node2NumericUpDown.Value);
                int newWeight = (int)this.WeightNumericUpDown.Value;

                if(newNode1 != null && newNode2 != null && newNode1 != newNode2)
                {
                    bool linkExists = newNode1.ConnectedLinks.Any(l =>
                        (l.ConnectedNodes.Item1 == newNode1 && l.ConnectedNodes.Item2 == newNode2) ||
                        (l.ConnectedNodes.Item2 == newNode1 && l.ConnectedNodes.Item1 == newNode2));

                    if(!linkExists)
                    {
                        this.graph.RemoveLink(this.selectedLink.Link);
                        this.selectedLink = new LinkDraw(this.graph.AddLink(newNode1, newNode2, newWeight));

                        RedrawPanel();
                    }
                    else if (linkExists && newWeight != this.selectedLink.Link.Weight)
                    {
                        this.selectedLink.Link.ChangeWeight(newWeight);

                        RedrawPanel();
                    }
                }
            }
        }

        //Open a save file dialog window and then export the graph using th exporter to the specified path. 
        private void SaveGraphButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Filter = "XML (*.xml)|*.xml"
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                this.exporter.Export(graph, path);
            }

            saveFileDialog.Dispose();
        }

        //Open a open file dialog windowand then import the graph from the specified path using importer.
        //Deselect link, node, source, destination, then set source and destination from the loaded graph. Redraw panel.
        private void LoadGraphButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = $"{Environment.CurrentDirectory}",
                Filter = "XML (*.xml)|*.xml"
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                this.graph = this.importer.Import(path, out this.currentMaxLayer);

                this.selectedNode = null;
                DeselectLink();
                this.source = null;
                this.destination = null;

                if (this.graph.Source != null)
                {
                    this.source = new NodeDraw(this.graph.Source);
                }
                if (this.graph.Destination != null)
                {
                    this.destination = new NodeDraw(this.graph.Destination);
                }

                RedrawPanel();
            }

            openFileDialog.Dispose();
        }

        //Set the maximum possible links depending on the nodes of the random graph generator.
        private void RandomNodesUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.RandomLinksUpDown.Maximum = this.RandomNodesUpDown.Value * ((this.RandomNodesUpDown.Value - 1) / 2);
        }

        //Get the inputed values for nodes and links. Delete the current graph. 
        //Create random non overlaping nodes and add them to the new graph.
        //Create random non existant links with random weights between existing nodes and add them to the graph.
        //Than deselect everything and redraw the panel.
        private void GenerateRandomButton_Click(object sender, EventArgs e)
        {
            decimal nodesCount = this.RandomNodesUpDown.Value;
            decimal linksCount = this.RandomLinksUpDown.Value;

            int nodesInGraph = this.graph.Nodes.Count;

            for (int i = 0; i < nodesInGraph; i++)
            {
                this.graph.RemoveNode(this.graph.Nodes[0]);
            }

            Random random = new Random();

            decimal createdNodes = 0;

            while(createdNodes < nodesCount)
            {
                int randomX = random.Next((int)Node.NODE_SIZE, this.Visualization.Width - (int)Node.NODE_SIZE);
                int randomY = random.Next((int)Node.NODE_SIZE, this.Visualization.Height - (int)Node.NODE_SIZE);

                IPoint center = new Point(randomX, randomY);

                if (!this.graph.Nodes.Any(n => CheckDistanceBetweenCenters(center, n.Center))) 
                {
                    this.currentMaxLayer += 1;

                    this.graph.AddNode(this.currentMaxLayer, center);

                    createdNodes += 1;
                }
            }

            decimal createdLinks = 0;

            while (createdLinks < linksCount)
            {
                int randomNode1 = random.Next(0, this.graph.Nodes.Count);
                int randomNode2 = random.Next(0, this.graph.Nodes.Count);

                if(randomNode1 == randomNode2)
                {
                    continue;
                }

                int weight = random.Next(MINIMUM_RANDOM_WEIGHT, MAXIMUM_RANDOM_WEIGHT);

                INode node1 = this.graph.Nodes[randomNode1];
                INode node2 = this.graph.Nodes[randomNode2];

                if (!node1.ConnectedLinks.Any(l => (l.ConnectedNodes.Item1 == node1 && l.ConnectedNodes.Item2 == node2) ||
                    (l.ConnectedNodes.Item1 == node2 && l.ConnectedNodes.Item2 == node1)))
                {
                    this.graph.AddLink(node1, node2, weight);

                    createdLinks += 1;
                }
            }

            DeselectLink();
            this.selectedNode = null;
            this.graph.Source = null;
            this.graph.Destination = null;
            this.source = null;
            this.destination = null;

            RedrawPanel();
        }

        //Checks if 2 nodes with specified centers are overlaping
        private bool CheckDistanceBetweenCenters(IPoint point1, IPoint point2)
        {
            double distance = Math.Sqrt(Math.Abs(point1.X - point2.X) * Math.Abs(point1.X - point2.X) + 
                Math.Abs(point1.Y - point2.Y) * Math.Abs(point1.Y - point2.Y));

            return distance <= 2 * Node.NODE_SIZE;
        }

        //If source and destination are specified open a new DijkstraAlgorithm form
        //If not display a message box.
        private void SimulateAlgorithmButton_Click(object sender, EventArgs e)
        {
            if(this.graph.Source != null && this.graph.Destination != null)
            {
                DijkstraAlgorithm djikstraAlgorithm = new DijkstraAlgorithm(this.graph);

                djikstraAlgorithm.Show();

                djikstraAlgorithm.DrawPanel();
            }
            else
            {
                MessageBox.Show("Source and/or Destination not selected", "Warning", MessageBoxButtons.OK);
            }
        }

        //If there is a selected node deselect source if any. If selected node is the destination deselect the destination.
        //Set the source to the selected node and redraw it in blue.
        private void SetSourceButton_Click(object sender, EventArgs e)
        {
            if(this.selectedNode != null)
            {
                if(this.source != null && this.source.Node != null)
                {
                    this.source.Draw(this.graphics, Color.Black);
                }

                if(this.destination != null && this.selectedNode.Node == this.destination.Node)
                {
                    this.destination = null;
                    this.graph.Destination = null;
                }

                this.source = this.selectedNode;
                this.graph.Source = this.source.Node;

                this.source.Draw(this.graphics, Color.Blue);
            }
        }

        //If there is a selected node deselect destination if any. If selected node is the source deselect the source.
        //Set the destination to the selected node and redraw it in green.
        private void SetDestinationButton_Click(object sender, EventArgs e)
        {
            if (this.selectedNode != null)
            {
                if (this.destination != null && this.destination.Node != null)
                {
                    this.destination.Draw(this.graphics, Color.Black);
                }

                if (this.source != null && this.selectedNode.Node == this.source.Node)
                {
                    this.source = null;
                    this.graph.Source = null;
                }

                this.destination = this.selectedNode;
                this.graph.Destination = this.destination.Node;

                this.destination.Draw(this.graphics, Color.Green);
            }
        }
    }
}
