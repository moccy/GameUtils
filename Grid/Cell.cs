using System.Collections.Generic;

namespace Lyut.Grid
{
    public class Cell
    {
        public Grid Grid { get; }
        public Face Face { get; }
        public IList<Edge> Edges { get; }
        public Position Position => Face.Position;
        public int X => Position.X;
        public int Y => Position.Y;

        public Vertex Vertex { get; }

        public Cell(Grid grid, int x, int y)
        {
            Grid = grid;
            Face = new Face(this, x, y);
            Edges = new List<Edge>
            {
                new Edge(this, x, y, Bearing.S),
                new Edge(this, x, y, Bearing.W),
            };
            Vertex = new Vertex(this, x, y);
        }
    }
}