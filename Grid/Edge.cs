using System;
using System.Collections.Generic;
using System.Linq;

namespace Lyut.Grid
{
    public class Edge
    {
        public Cell Cell { get; }
        public Position Position { get; set; }
        public Bearing Bearing { get; set; }

        public Edge(Cell cell, int x, int y, Bearing bearing)
        {
            Cell = cell;
            Position = new Position(x, y);
            Bearing = bearing;
        }

        public IEnumerable<Face> Joins()
        {
            var joins = new List<Face> { Cell.Face };
            switch (Bearing)
            {
                case Bearing.W:
                    joins.Add(Cell.Grid.Cells.Select(x => x.Face)
                        .FirstOrDefault(x => x.Position.X == Position.X - 1 && x.Position.Y == Position.Y));
                    break;
                case Bearing.S:
                    joins.Add(Cell.Grid.Cells.Select(x => x.Face)
                        .FirstOrDefault(x => x.Position.X == Position.X && x.Position.Y == Position.Y - 1));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return joins.Where(x => x != null);
        }

        public IEnumerable<Edge> Continues()
        {
            if (Bearing == Bearing.S)
            {
                return Cell.Grid.Cells.SelectMany(x => x.Edges).Where(e =>
                    e.Bearing == Bearing.S && (
                    e.Position.X == Position.X + 1 && e.Position.Y == Position.Y ||
                    e.Position.X == Position.X - 1 && e.Position.Y == Position.Y)
                );
            }
            return Cell.Grid.Cells.SelectMany(x => x.Edges).Where(e =>
                e.Bearing == Bearing.S && (
                e.Position.X == Position.X && e.Position.Y == Position.Y - 1 ||
                e.Position.X == Position.X && e.Position.Y == Position.Y - 1)
            );
        }

        public IEnumerable<Vertex> Endpoints()
        {
            var endpoints = new List<Vertex> { Cell.Vertex };

            if (Bearing == Bearing.S)
            {
                endpoints.Add(Cell.Grid.Cells.Select(x => x.Vertex).FirstOrDefault(x =>
                    x.Position.X == Position.X + 1 && x.Position.Y == Position.Y));
            }
            else
            {
                endpoints.Add(Cell.Grid.Cells.Select(x => x.Vertex).FirstOrDefault(x =>
                    x.Position.X == Position.X && x.Position.Y == Position.Y + 1));
            }

            return endpoints;
        }
    }
}