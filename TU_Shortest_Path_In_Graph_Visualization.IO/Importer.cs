using System.IO;
using System.Linq;
using System.Xml.Serialization;

using TU_Shortest_Path_In_Graph_Visualization.IO.Contracts;
using TU_Shortest_Path_In_Graph_Visualization.IO.Dtos;
using TU_Shortest_Path_In_Graph_Vizualisation.Models;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization.IO
{
    public class Importer : IImporter
    {
        //Import the GraphDto from a xml file then get the new graph then set the current max layer
        public IGraph Import(string path, out int currentMaxLayer)
        {
            GraphDto graphDto = ImportGraphDtoFromXml(path);

            GetGraphFromDto(graphDto, out IGraph graph);

            //Set the maxLayer to the highest number.
            currentMaxLayer = graph.Nodes.OrderByDescending(n => n.Layer).ToArray()[0].Layer;

            return graph;
        }

        //Get the data for nodes and links from GraphDto and add them to the new graph than set the source and destination if any
        private static void GetGraphFromDto(GraphDto graphDto, out IGraph graph)
        {
            graph = new Graph(graphDto.Nodes.Count + 1);

            foreach (NodeDto nodeDto in graphDto.Nodes)
            {
                graph.AddExistingNode(nodeDto.Layer, nodeDto.NodeNumber, nodeDto.CenterX, nodeDto.CenterY);
            }

            foreach (NodeDto nodeDto in graphDto.Nodes)
            {
                foreach (LinkDto linkDto in nodeDto.ConnectedLinks)
                {
                    INode node1 = graph.Nodes.First(n => n.NodeNumber == linkDto.Node1);
                    INode node2 = graph.Nodes.First(n => n.NodeNumber == linkDto.Node2);

                    bool linkExists = node1.ConnectedLinks.Any(l =>
                        (l.ConnectedNodes.Item1 == node1 && l.ConnectedNodes.Item2 == node2) ||
                        (l.ConnectedNodes.Item1 == node2 && l.ConnectedNodes.Item2 == node1));

                    if(!linkExists)
                    {
                        graph.AddLink(node1, node2, linkDto.Weight);
                    }
                }
            }

            if(graphDto.Source != 0)
            {
                graph.Source = graph.Nodes.First(n => n.NodeNumber == graphDto.Source);
            }
            else
            {
                graph.Source = null;
            }

            if (graphDto.Destination != 0)
            {
                graph.Destination = graph.Nodes.First(n => n.NodeNumber == graphDto.Destination);
            }
            else
            {
                graph.Destination = null;
            }
        }

        //Using a XmlSerializer import the data from a specified xml file into a GraphDto object 
        private static GraphDto ImportGraphDtoFromXml(string path)
        {
            XmlRootAttribute rootAttribute = new XmlRootAttribute("Graph");

            XmlSerializer serializer = new XmlSerializer(typeof(GraphDto), rootAttribute);

            StreamReader streamReader = new StreamReader(path);

            GraphDto graphDto = (GraphDto)serializer.Deserialize(streamReader);

            streamReader.Dispose();

            return graphDto;
        }
    }
}
