using NUnit.Framework;
using System;

namespace SudokuTests
{
    [TestFixture]
    public class Cell
    {
        [Test]
        public void UnknownInitialozation()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[2U, 8U];
            Assert.True(cell.IsUnknown);
            Assert.False(cell.IsGiven);
            Assert.False(cell.IsSolved);
        }

        [Test]
        public void GivenValue()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[8U, 8U];
            cell.Value = 5U;
            Assert.True(cell.IsGiven);
            Assert.False(cell.IsUnknown);
            Assert.False(cell.IsSolved);
        }

        [Test]
        public void TestValue()
        {
            uint value = 5U;
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[4U, 7U];
            cell.Value = value;
            Assert.AreEqual(value, cell.Value);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidValue()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(3U);
            SudokuSolver.Cell cell = sudoku[4U, 7U];
            cell.Value = 150U;
        }

        [Test]
        public void StringValue()
        {
            SudokuSolver.Sudoku sudoku = new SudokuSolver.Sudoku(10U);
            SudokuSolver.Cell cell = sudoku[99U, 97U];
            Assert.AreEqual("Cell[99, 97]", cell.ToString());
        }
    }
}