using System;

using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Models
{
    public class Link : ILink
    {
        public Link(INode node1, INode node2, int weight)
        {
            this.Weight = weight;
            this.ConnectedNodes = new Tuple<INode, INode>(node1, node2);
        }

        public Tuple<INode, INode> ConnectedNodes { get; private set; }

        public int Weight { get; private set; }

        //Changes the weight
        public void ChangeWeight(int newWeight)
        {
            this.Weight = newWeight;
        }

        //Checks if a point is on the line representing the link. 
        //Check is deliberatly not perfect in order to make link selection easier
        public bool Contains(IPoint point)
        {
            double x1 = this.ConnectedNodes.Item1.Center.X;
            double y1 = this.ConnectedNodes.Item1.Center.Y;
            double x2 = this.ConnectedNodes.Item2.Center.X;
            double y2 = this.ConnectedNodes.Item2.Center.Y;
            double m = (y2 - y1) / (x2 - x1);
            //y = mx + b => b = y - mx
            double b = y1 - (m * x1);
            
            return point.Y >= Math.Floor((m * point.X) + b) - 3 && 
                point.Y <= Math.Floor((m * point.X) + b) + 3 && 
                point.X >= Math.Min(x1, x2) && 
                point.X <= Math.Max(x1, x2) &&
                point.Y >= Math.Min(y1, y2) &&
                point.Y <= Math.Max(y1, y2);
        }
    }
}
