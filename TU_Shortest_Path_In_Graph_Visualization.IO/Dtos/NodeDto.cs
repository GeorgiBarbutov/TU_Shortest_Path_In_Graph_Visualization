using System.Collections.Generic;
using System.Xml.Serialization;

namespace TU_Shortest_Path_In_Graph_Visualization.IO.Dtos
{
    [XmlType("Node")]
    public class NodeDto
    {
        [XmlElement("NodeNumber")]
        public int NodeNumber { get; set; }

        [XmlElement("Layer")]
        public int Layer { get; set; }

        [XmlElement("CenterX")]
        public float CenterX { get; set; }

        [XmlElement("CenterY")]
        public float CenterY { get; set; }

        [XmlArray("ConnectedLinks")]
        public List<LinkDto> ConnectedLinks { get; set; }
    }
}
