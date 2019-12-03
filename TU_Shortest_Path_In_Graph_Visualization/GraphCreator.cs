using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public GraphCreator()
        {
            InitializeComponent();

            this.graph = new Graph();
            this.selectedLink = null;
            this.selectedNode = null;
            this.currentMaxLayer = DEFAULT_CURRENT_MAX_LAYER;

            this.graphics = this.Visualization.CreateGraphics();
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            INode a = this.graph.AddNode(4);
            a.Move(40, 56);
            a.Draw(this.graphics, Color.Black);
            INode b = this.graph.AddNode(5);
            b.Draw(this.graphics, Color.Black);
            ILink l1 = this.graph.AddLink(a, b, 5);
            l1.Draw(this.graphics, Color.Black);
            a.Draw(this.graphics, Color.Black);
            b.Draw(this.graphics, Color.Black);
        }

        private void Visualization_MouseClick(object sender, MouseEventArgs e)
        {
            this.graph.Nodes.First().Move(12, 12);
            this.graph.Nodes.First().Draw(this.graphics, Color.Black);
            this.graph.Nodes.First().Move(12, 12);
            this.graph.Nodes.First().Draw(this.graphics, Color.Black);
            if (this.graph.Nodes.First().Contains(e.Location))
            {
                this.graph.Nodes.First().Outline(this.graphics, Color.Aqua);
            }
        }
    }
}
