using System.Collections.Generic;

namespace Lyut.Grid
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }
        public IEnumerable<Cell> Cells { get; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = GenerateCells();
        }

        private IEnumerable<Cell> GenerateCells()
        {
            var cells = new Cell[Width * Height];
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    cells[i * Width + j] = new Cell(this, j, i);
                }
            }

            return cells;
        }
    }
}