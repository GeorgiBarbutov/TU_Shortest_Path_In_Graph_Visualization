using System.Collections.Generic;
using System.Xml.Serialization;

namespace TU_Shortest_Path_In_Graph_Visualization.IO.Dtos
{
    [XmlRoot("Graph")]
    public class GraphDto
    {
        [XmlArray("Nodes")]
        public List<NodeDto> Nodes { get; set; }

        [XmlElement("Source")]
        public int Source { get; set; }

        [XmlElement("Destination")]
        public int Destination { get; set; }
    }
}
