using System.Xml.Serialization;

namespace TU_Shortest_Path_In_Graph_Visualization.IO.Dtos
{
    [XmlType("Link")]
    public class LinkDto
    {
        [XmlElement("Weight")]
        public int Weight { get; set; }

        [XmlElement("Node1")]
        public int Node1 { get; set; }

        [XmlElement("Node2")]
        public int Node2 { get; set; }
    }
}
