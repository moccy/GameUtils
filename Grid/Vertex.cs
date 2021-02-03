using System.Collections.Generic;
using System.Linq;

namespace Lyut.Grid
{
    public class Vertex
    {
        public Cell Cell { get; }
        public Position Position { get; set; }

        public Vertex(Cell cell, int x, int y)
        {
            Cell = cell;
            Position = new Position(x, y);
        }

        public IEnumerable<Face> Touches()
        {
            var touches = new List<Face> { Cell.Face };
            touches.AddRange(Cell.Grid.Cells.Select(x => x.Face).Where(face =>
                face.Position.X == Position.X - 1 && face.Position.Y == Position.Y ||       // Top-Left
                face.Position.X == Position.X - 1 && face.Position.Y == Position.Y - 1 ||   // Bottom-Left
                face.Position.X == Position.X && face.Position.Y == Position.Y - 1          // Bottom Right
            ));
            return touches;
        }

        public IEnumerable<Edge> Protrudes()
        {
            var protrusions = new List<Edge>(Cell.Edges);

            protrusions.AddRange(Cell.Grid.Cells.SelectMany(x => x.Edges).Where(e =>
                e.Position.X == Position.X - 1 && e.Position.Y == Position.Y && e.Bearing == Bearing.S ||
                e.Position.X == Position.X && e.Position.Y == Position.Y - 1 && e.Bearing == Bearing.W
            ));

            return protrusions;
        }

        public IEnumerable<Vertex> Adjacent()
        {
            return Cell.Grid.Cells.Select(x => x.Vertex).Where(v =>
                v.Position.X == Position.X && v.Position.Y == Position.Y + 1 || // Top
                v.Position.X == Position.X + 1 && v.Position.Y == Position.Y || // Right
                v.Position.X == Position.X && v.Position.Y == Position.Y - 1 || // Down
                v.Position.X == Position.X - 1 && v.Position.Y == Position.Y    // Left
            );
        }
    }
}