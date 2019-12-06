using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TU_Shortest_Path_In_Graph_Vizualisation.Models;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization
{
    public partial class GraphCreator : Form
    {
        private const int DEFAULT_CURRENT_MAX_LAYER = 0;

        private IGraph graph;
        private INode selectedNode;
        private ILink selectedLink;
        private int currentMaxLayer;
        private Graphics graphics;
        private int mouseDownXCoordinate;
        private int mouseDownYCoordinate;

        public GraphCreator()
        {
            InitializeComponent();

            this.graph = new Graph();
            this.selectedLink = null;
            this.selectedNode = null;
            this.currentMaxLayer = DEFAULT_CURRENT_MAX_LAYER;

            this.graphics = this.Visualization.CreateGraphics();
        }

        private void RedrawPanel()
        {
            this.Visualization.Refresh();

            foreach (INode node in this.graph.Nodes.OrderBy(n => n.Layer))
            {
                foreach (ILink link in node.ConnectedLinks)
                {
                    if (link == this.selectedLink)
                    {
                        link.Draw(this.graphics, Color.Red);
                    }
                    else
                    {
                        link.Draw(this.graphics, Color.Black);
                    }
                }
            }

            foreach (INode node in this.graph.Nodes.OrderBy(n => n.Layer))
            {
                if (node == this.selectedNode)
                {
                    node.Draw(this.graphics, Color.Red);
                }
                else
                {
                    node.Draw(this.graphics, Color.Black);
                }
            }
        }

        private void DeselectLink()
        {
            this.selectedLink = null;
            this.Node1NumericUpDown.Value = 0;
            this.Node2NumericUpDown.Value = 0;
            this.WeightNumericUpDown.Value = 0;
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            this.currentMaxLayer += 1;

            INode node = this.graph.AddNode(this.currentMaxLayer);

            this.selectedNode = null;
            DeselectLink();

            RedrawPanel();
        }

        private void RemoveNodeButton_Click(object sender, EventArgs e)
        {
            if (this.selectedNode != null)
            {
                this.graph.RemoveNode(this.selectedNode);

                this.selectedNode = null;

                RedrawPanel();
            }
        }

        private void Visualization_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownXCoordinate = e.X;
            this.mouseDownYCoordinate = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                PointF cursorPosition = new PointF(e.X, e.Y);

                if (this.selectedNode != null)
                {
                    this.selectedNode.Draw(this.graphics, Color.Black);
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

                        this.selectedNode = node;
                        DeselectLink();

                        this.selectedNode.ChangeCurrentLayer(this.currentMaxLayer);

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
                                this.selectedLink = link;
                                this.selectedNode = null;

                                this.selectedLink.Draw(this.graphics, Color.Red);

                                this.Node1NumericUpDown.Value = this.selectedLink.ConnectedNodes.Item1.NodeNumber;
                                this.Node2NumericUpDown.Value = this.selectedLink.ConnectedNodes.Item2.NodeNumber;
                                this.WeightNumericUpDown.Value = this.selectedLink.Weight;

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

        private void Visualization_MouseUp(object sender, MouseEventArgs e)
        {
            RedrawPanel();
        }

        private void Visualization_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.selectedNode != null && e.Button == MouseButtons.Left)
            {
                this.selectedNode.Draw(this.graphics, Color.White);

                this.selectedNode.Move(e.X - this.mouseDownXCoordinate, e.Y - this.mouseDownYCoordinate);

                this.selectedNode.Draw(this.graphics, Color.Red);

                this.mouseDownXCoordinate = e.X;
                this.mouseDownYCoordinate = e.Y;
            }
        }

        private void AddLinkButton_Click(object sender, EventArgs e)
        {
            INode node1 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node1NumericUpDown.Value);
            INode node2 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node2NumericUpDown.Value);

            if(node1 != null && node2 != null)
            {
                bool linkExists = node1.ConnectedLinks.Any(l => 
                    (l.ConnectedNodes.Item1 == node1 && l.ConnectedNodes.Item2 == node2) || 
                    (l.ConnectedNodes.Item2 == node1 && l.ConnectedNodes.Item1 == node2));

                if(!linkExists)
                {
                    ILink link = this.graph.AddLink(node1, node2, (int)this.WeightNumericUpDown.Value);

                    this.selectedNode = null;
                    DeselectLink();

                    RedrawPanel();
                }
            }
        }

        private void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            if (this.selectedLink != null)
            {
                this.graph.RemoveLink(this.selectedLink);

                DeselectLink();

                RedrawPanel();
            }
        }

        private void EditLinkButton_Click(object sender, EventArgs e)
        {
            if(this.selectedLink != null)
            {
                INode newNode1 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node1NumericUpDown.Value);
                INode newNode2 = this.graph.Nodes.FirstOrDefault(n => n.NodeNumber == this.Node2NumericUpDown.Value);
                int newWeight = (int)this.WeightNumericUpDown.Value;

                if(newNode1 != null && newNode2 != null)
                {
                    bool linkExists = newNode1.ConnectedLinks.Any(l =>
                        (l.ConnectedNodes.Item1 == newNode1 && l.ConnectedNodes.Item2 == newNode2) ||
                        (l.ConnectedNodes.Item2 == newNode1 && l.ConnectedNodes.Item1 == newNode2));

                    if(!linkExists)
                    {
                        this.graph.RemoveLink(this.selectedLink);
                        this.selectedLink = this.graph.AddLink(newNode1, newNode2, newWeight);

                        RedrawPanel();
                    }
                    else if (linkExists && newWeight != this.selectedLink.Weight)
                    {
                        this.selectedLink.ChangeWeight(newWeight);

                        RedrawPanel();
                    }
                }
            }
        }
    }
}
