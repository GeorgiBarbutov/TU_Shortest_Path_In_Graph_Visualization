using System.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts
{
    public interface ILinkDraw
    {
        ILink Link { get; }

        void Draw(Graphics graphics, Color color);
    }
}
