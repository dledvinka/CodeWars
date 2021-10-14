using System.Collections.Generic;
using CodeWars.ConsoleApp;
using NUnit.Framework;

namespace CodeWars.Tests
{
    public class GridWithColouredCellsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var cells = new List<GridCell>()
            {
                new GridCell(0, 0, Colour.Blue),
                new GridCell(1, 0, Colour.Red),
                new GridCell(2, 0, Colour.Red),
                new GridCell(3, 0, Colour.Red),

                new GridCell(0, 1, Colour.Green),
                new GridCell(1, 1, Colour.Red),
                new GridCell(2, 1, Colour.Blue),
                new GridCell(3, 1, Colour.Red),

                new GridCell(0, 2, Colour.Green),
                new GridCell(1, 2, Colour.Green),
                new GridCell(2, 2, Colour.Blue),
                new GridCell(3, 2, Colour.Blue),
            };

            var grid = new Grid(4, 3, cells.ToArray());
            Assert.AreEqual(5, grid.GetLargestContinuousArea());
        }
    }
}