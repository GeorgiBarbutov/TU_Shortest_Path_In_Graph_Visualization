using System.Collections.Generic;
using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Link : ILink
    {
        public Link(INode node1, INode node2, float weight)
        {
            this.Weight = weight;
            this.ConnectedNodes = new KeyValuePair<INode, INode>(node1, node2);

            node1.AddLink(this);
            node2.AddLink(this);
        }

        public KeyValuePair<INode, INode> ConnectedNodes { get; private set; }

        public float Weight { get; private set; }

        public void Draw(Graphics graphics)
        {
            //TODO:
        }
    }
}
