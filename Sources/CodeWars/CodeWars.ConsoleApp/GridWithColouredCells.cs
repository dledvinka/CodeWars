using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CodeWars.ConsoleApp
{
    public class Grid
    {
        private readonly int _sizeX;
        private readonly int _sizeY;
        private readonly GridCell[] _cells;

        public Grid(int sizeX, int sizeY, GridCell[] cells)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _cells = cells;
        }

        public int GetLargestContinuousArea()
        {
            var results = Enum.GetValues<Colour>().ToDictionary(t => t, t => 0);

            for (int x = 0; x < _sizeX; x++)
            {
                for (int y = 0; y < _sizeY; y++)
                {
                    int connectedCount = 1;
                    var currentCell = _cells.Single(cell => cell.X == x && cell.Y == y);

                    var sourceCells = new List<GridCell>() {currentCell};
                    var scannedCells = new List<GridCell>() {currentCell};

                    var newNeighbours = GetNeighbours(sourceCells, scannedCells);

                    while (newNeighbours.Any())
                    {
                        connectedCount += newNeighbours.Count;
                        newNeighbours = GetNeighbours(newNeighbours, scannedCells);
                    }

                    if (results[currentCell.Colour] < connectedCount)
                    {
                        results[currentCell.Colour] = connectedCount;
                    }
                }
            }

            return results.Values.Max();
        }

        private List<GridCell> GetNeighbours(List<GridCell> sourceCells, List<GridCell> scannedCells)
        {
            var neighbours = new List<GridCell>();

            foreach (var sourceCell in sourceCells)
            {
                neighbours.AddRange(GetNeighbours(sourceCell, scannedCells));
            }

            return neighbours;
        }

        private List<GridCell> GetNeighbours(GridCell sourceCell, List<GridCell> scannedCells)
        {
            var neighbours = new List<GridCell>()
            {
                _cells.FirstOrDefault(cell => cell.X == sourceCell.X + 1 && cell.Y == sourceCell.Y), // right
                _cells.FirstOrDefault(cell => cell.X == sourceCell.X - 1 && cell.Y == sourceCell.Y), // left
                _cells.FirstOrDefault(cell => cell.X == sourceCell.X && cell.Y == sourceCell.Y + 1), // up
                _cells.FirstOrDefault(cell => cell.X == sourceCell.X && cell.Y == sourceCell.Y - 1), // down
            };

            neighbours = neighbours.Where(
                cell => cell != null && 
                cell.X >= 0 && 
                cell.X < _sizeX 
                && cell.Y >= 0 
                && cell.Y < _sizeY
                && cell.Colour == sourceCell.Colour)
                .ToList();

            neighbours = neighbours.Where(cell => !scannedCells.Contains(cell)).ToList();
            
            scannedCells.AddRange(neighbours);

            return neighbours;
        }
    }

    public class GridCell : IEquatable<GridCell>
    {
        public int X { get; }
        public int Y { get; }
        public Colour Colour { get; }

        public GridCell(int x, int y, Colour colour)
        {
            X = x;
            Y = y;
            Colour = colour;
        }

        public bool Equals(GridCell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y && Colour == other.Colour;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GridCell) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, (int) Colour);
        }
    }

    public enum Colour
    {
        None,
        Red,
        Green,
        Blue
    }
}