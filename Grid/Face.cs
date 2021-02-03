using System.Collections.Generic;
using System.Linq;

namespace Lyut.Grid
{
    public class Face
    {
        public Cell Cell { get; }

        public Position Position { get; set; }

        public Face(Cell cell, int x, int y)
        {
            Cell = cell;
            Position = new Position(x, y);
        }

        public IEnumerable<Face> Neighbours()
        {
            return Cell.Grid.Cells.Select(x => x.Face).Where(face =>
                face.Position.X == Position.X && face.Position.Y == Position.Y + 1 || // North
                face.Position.X == Position.X + 1 && face.Position.Y == Position.Y || // East
                face.Position.X == Position.X && face.Position.Y == Position.Y - 1 || // South
                face.Position.X == Position.X - 1 && face.Position.Y == Position.Y);  // West
        }

        public IEnumerable<Edge> Borders()
        {

            return Cell.Edges.Concat(Cell.Grid.Cells.SelectMany(x => x.Edges).Where(edge =>
                edge.Position.X == Position.X && edge.Position.Y == Position.Y + 1 && edge.Bearing == Bearing.S ||  // North
                edge.Position.X == Position.X + 1 && edge.Position.Y == Position.Y && edge.Bearing == Bearing.W     // East
            ));
        }

        public IEnumerable<Vertex> Corners()
        {
            var corners = new List<Vertex> { Cell.Vertex };
            corners.AddRange(Cell.Grid.Cells.Select(x => x.Vertex).Where(vertex =>
                vertex.Position.X == Position.X && vertex.Position.Y == Position.Y + 1 ||       // NW
                vertex.Position.X == Position.X + 1 && vertex.Position.Y == Position.Y + 1 ||   // NE
                vertex.Position.X == Position.X + 1 && vertex.Position.Y == Position.Y          // SE
            ));
            return corners;
        }
    }
}