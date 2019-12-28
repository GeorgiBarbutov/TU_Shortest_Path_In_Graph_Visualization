using System.IO;
using System.Linq;
using System.Xml.Serialization;

using TU_Shortest_Path_In_Graph_Visualization.IO.Contracts;
using TU_Shortest_Path_In_Graph_Visualization.IO.Dtos;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization.IO
{
    public class Exporter : IExporter
    {
        private IGraph graph;

        //Get GraphDto and export it.
        public void Export(IGraph graph, string path)
        {
            this.graph = graph;

            GraphDto graphDto = GetDto();

            Export(graphDto, path);
        }

        //Convert the data of nodes and links in the graph into a GraphDto object
        private GraphDto GetDto()
        {
            return new GraphDto
            {
                Source = this.graph.Source != null ? this.graph.Source.NodeNumber : 0,
                Destination = this.graph.Destination != null ? this.graph.Destination.NodeNumber : 0,
                Nodes = this.graph.Nodes.Select(n => new NodeDto
                {
                    CenterX = n.Center.X,
                    CenterY = n.Center.Y,
                    Layer = n.Layer,
                    NodeNumber = n.NodeNumber,
                    ConnectedLinks = n.ConnectedLinks.Select(l => new LinkDto
                    {
                        Weight = l.Weight,
                        Node1 = l.ConnectedNodes.Item1.NodeNumber,
                        Node2 = l.ConnectedNodes.Item2.NodeNumber
                    }).ToList()
                }).ToList()
            };
        }

        //Using a XmlSerializer export the GraphDto object to a xml file at a specified path.
        public void Export(GraphDto graphDto, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GraphDto), new XmlRootAttribute("Graph"));

            StreamWriter streamWriter = new StreamWriter(path);

            serializer.Serialize(streamWriter, graphDto);

            streamWriter.Dispose();
        }
    }
}
